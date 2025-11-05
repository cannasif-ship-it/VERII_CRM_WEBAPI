import React, { useEffect, useState } from 'react';
import { CityHelper } from '../Hooks/CityHelper';
import { ApiResponse } from '../Models/ApiResponse';
import { CityGetDto } from '../Models/CityDto';

export const ApiCallTemplate: React.FC = () => {
  const [cities, setCities] = useState<CityGetDto[]>([]);
  const [loading, setLoading] = useState<boolean>(false);
  const [error, setError] = useState<string>('');

  const fetchCities = async () => {
    setLoading(true);
    setError('');
    try {
      const response: ApiResponse<CityGetDto[]> = await CityHelper.getAllCities();
      if (response.success && response.data) {
        setCities(response.data);
      } else {
        setError(response.message || 'Beklenmeyen hata');
      }
    } catch (e: any) {
      setError(e?.message || 'İstek sırasında hata oluştu');
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchCities();
  }, []);

  return (
    <div style={{ padding: 16 }}>
      <h2>API Çağrısı Örneği (Şehirler)</h2>
      <button onClick={fetchCities} disabled={loading}>
        {loading ? 'Yükleniyor...' : 'Yenile'}
      </button>
      {error && <p style={{ color: 'red' }}>{error}</p>}
      <ul>
        {cities.map((c) => (
          <li key={c.id}>
            {c.name} {c.countryName ? `- ${c.countryName}` : ''}
          </li>
        ))}
      </ul>
    </div>
  );
};