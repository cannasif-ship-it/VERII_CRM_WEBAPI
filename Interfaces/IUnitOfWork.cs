using cms_webapi.Models;

namespace cms_webapi.Interfaces
{
    /// <summary>
    /// Unit of Work pattern interface for managing transactions and repositories
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// User repository
        /// </summary>
        IGenericRepository<User> Users { get; }
        IGenericRepository<Country> Countries { get; }
        IGenericRepository<City> Cities { get; }
        IGenericRepository<District> Districts { get; }
        IGenericRepository<CustomerType> CustomerTypes { get; }
        IGenericRepository<Customer> Customers { get; }
        IGenericRepository<Title> Titles { get; }
        IGenericRepository<Contact> Contacts { get; }
        IGenericRepository<Activity> Activities { get; }
        IGenericRepository<ProductPricing> ProductPricings { get; }
        IGenericRepository<ProductPricingGroupBy> ProductPricingGroupBys { get; }
        IGenericRepository<UserDiscountLimit> UserDiscountLimits { get; }
        IGenericRepository<PaymentType> PaymentTypes { get; }
        IGenericRepository<ShippingAddress> ShippingAddresses { get; }
        IGenericRepository<Quotation> Quotations { get; }



        /// <summary>
        /// Save all changes to the database within a transaction
        /// </summary>
        /// <returns>Number of affected rows</returns>
        Task<int> SaveChangesAsync();

        /// <summary>
        /// Begin a new transaction
        /// </summary>
        Task BeginTransactionAsync();

        /// <summary>
        /// Commit the current transaction
        /// </summary>
        Task CommitTransactionAsync();

        /// <summary>
        /// Rollback the current transaction
        /// </summary>
        Task RollbackTransactionAsync();

        /// <summary>
        /// Get repository for any entity type
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <returns>Generic repository for the entity</returns>
        IGenericRepository<T> Repository<T>() where T : BaseEntity;
    }
}
