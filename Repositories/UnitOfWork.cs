using cms_webapi.Data;
using cms_webapi.Interfaces;
using cms_webapi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Concurrent;
using Microsoft.AspNetCore.Http;

namespace cms_webapi.Repositories
{
    /// <summary>
    /// Unit of Work implementation for managing transactions and repositories
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CmsDbContext _context;
        private readonly ConcurrentDictionary<Type, object> _repositories;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private IDbContextTransaction? _transaction;
        private bool _disposed = false;

        // Lazy initialization of repositories
        private IGenericRepository<User>? _users;
        private IGenericRepository<Country>? _countries;
        private IGenericRepository<City>? _cities;
        private IGenericRepository<District>? _districts;
        private IGenericRepository<CustomerType>? _customerTypes;
        private IGenericRepository<Customer>? _customers;
        private IGenericRepository<Title>? _titles;
        private IGenericRepository<Contact>? _contacts;
        private IGenericRepository<Activity>? _activities;
        private IGenericRepository<PaymentType>? _paymentTypes;
        private IGenericRepository<ProductPricing>? _productPricings;
        private IGenericRepository<ProductPricingGroupBy>? _productPricingGroupBys;
        private IGenericRepository<UserDiscountLimit>? _userDiscountLimits;
        private IGenericRepository<ShippingAddress>? _shippingAddresses;
        private IGenericRepository<Quotation>? _quotations;

        public UnitOfWork(CmsDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _repositories = new ConcurrentDictionary<Type, object>();
        }

        /// <summary>
        /// repository property
        /// </summary>
        public IGenericRepository<User> Users{get{_users ??= new GenericRepository<User>(_context, _httpContextAccessor);return _users;}}
        public IGenericRepository<Country> Countries{get{_countries ??= new GenericRepository<Country>(_context, _httpContextAccessor);return _countries;}}
        public IGenericRepository<City> Cities{get{_cities ??= new GenericRepository<City>(_context, _httpContextAccessor);return _cities;}}
        public IGenericRepository<District> Districts{get{_districts ??= new GenericRepository<District>(_context, _httpContextAccessor);return _districts;}}
        public IGenericRepository<CustomerType> CustomerTypes{get{_customerTypes ??= new GenericRepository<CustomerType>(_context, _httpContextAccessor);return _customerTypes;}} 
        public IGenericRepository<Customer> Customers{get{_customers ??= new GenericRepository<Customer>(_context, _httpContextAccessor);return _customers;}}
        public IGenericRepository<Title> Titles{get{_titles ??= new GenericRepository<Title>(_context, _httpContextAccessor);return _titles;}}
        public IGenericRepository<Contact> Contacts{get{_contacts ??= new GenericRepository<Contact>(_context, _httpContextAccessor);return _contacts;}}
        public IGenericRepository<Activity> Activities{get{_activities ??= new GenericRepository<Activity>(_context, _httpContextAccessor);return _activities;}}
        public IGenericRepository<PaymentType> PaymentTypes{get{_paymentTypes ??= new GenericRepository<PaymentType>(_context, _httpContextAccessor);return _paymentTypes;}}

        public IGenericRepository<ProductPricing> ProductPricings{get{_productPricings ??= new GenericRepository<ProductPricing>(_context, _httpContextAccessor);return _productPricings;}}
        public IGenericRepository<ProductPricingGroupBy> ProductPricingGroupBys{get{_productPricingGroupBys ??= new GenericRepository<ProductPricingGroupBy>(_context, _httpContextAccessor);return _productPricingGroupBys;}}
        public IGenericRepository<UserDiscountLimit> UserDiscountLimits{get{_userDiscountLimits ??= new GenericRepository<UserDiscountLimit>(_context, _httpContextAccessor);return _userDiscountLimits;}}
        public IGenericRepository<ShippingAddress> ShippingAddresses{get{_shippingAddresses ??= new GenericRepository<ShippingAddress>(_context, _httpContextAccessor);return _shippingAddresses;}}
        public IGenericRepository<Quotation> Quotations{get{_quotations ??= new GenericRepository<Quotation>(_context, _httpContextAccessor);return _quotations;}}


        /// <summary>
        /// Get repository for any entity type
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <returns>Generic repository for the entity</returns>
        public IGenericRepository<T> Repository<T>() where T : BaseEntity
        {
            return (IGenericRepository<T>)_repositories.GetOrAdd(typeof(T), 
                _ => new GenericRepository<T>(_context, _httpContextAccessor));
        }

        /// <summary>
        /// Save all changes to the database
        /// </summary>
        /// <returns>Number of affected rows</returns>
        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                // If we have an active transaction, rollback
                if (_transaction != null)
                {
                    await RollbackTransactionAsync();
                }
                throw;
            }
        }

        /// <summary>
        /// Begin a new transaction
        /// </summary>
        public async Task BeginTransactionAsync()
        {
            if (_transaction != null)
            {
                throw new InvalidOperationException("A transaction is already in progress.");
            }

            _transaction = await _context.Database.BeginTransactionAsync();
        }

        /// <summary>
        /// Commit the current transaction
        /// </summary>
        public async Task CommitTransactionAsync()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("No transaction is in progress.");
            }

            try
            {
                await _transaction.CommitAsync();
            }
            catch
            {
                await RollbackTransactionAsync();
                throw;
            }
            finally
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        /// <summary>
        /// Rollback the current transaction
        /// </summary>
        public async Task RollbackTransactionAsync()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("No transaction is in progress.");
            }

            try
            {
                await _transaction.RollbackAsync();
            }
            finally
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        /// <summary>
        /// Dispose resources
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Protected dispose method
        /// </summary>
        /// <param name="disposing">Whether disposing</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _transaction?.Dispose();
                _context?.Dispose();
                _disposed = true;
            }
        }
    }
}
