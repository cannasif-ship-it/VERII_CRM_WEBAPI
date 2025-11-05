import React, { useState } from 'react';
import { AuthHelper } from '../Hooks/AuthHelper';
import { setAuthToken } from '../baseUrl';
import { ApiResponse } from '../Models/ApiResponse';
import { LoginDto, LoginResponseDto } from '../Models/AuthDto';

export const LoginTemplate: React.FC = () => {
  const [usernameOrEmail, setUsernameOrEmail] = useState<string>('');
  const [password, setPassword] = useState<string>('');
  const [loading, setLoading] = useState<boolean>(false);
  const [error, setError] = useState<string>('');
  const [successMsg, setSuccessMsg] = useState<string>('');
  const [user, setUser] = useState<LoginResponseDto['user'] | null>(null);

  const onSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setLoading(true);
    setError('');
    setSuccessMsg('');
    setUser(null);
    try {
      const payload: LoginDto = { usernameOrEmail, password };
      const res: ApiResponse<LoginResponseDto> = await AuthHelper.login(payload);
      if (res.success && res.data) {
        setAuthToken(res.data.token);
        setUser(res.data.user);
        setSuccessMsg('Giriş başarılı. Token saklandı.');
      } else {
        setError(res.message || 'Giriş başarısız');
      }
    } catch (e: any) {
      setError(e?.message || 'İstek sırasında hata oluştu');
    } finally {
      setLoading(false);
    }
  };

  return (
    <div style={{ padding: 16, maxWidth: 400 }}>
      <h2>Login Örneği</h2>
      <form onSubmit={onSubmit}>
        <div style={{ marginBottom: 8 }}>
          <label>
            Kullanıcı Adı veya Email
            <input
              type="text"
              value={usernameOrEmail}
              onChange={(e) => setUsernameOrEmail(e.target.value)}
              placeholder="email@domain.com veya kullanıcı adı"
              style={{ width: '100%', padding: 8, marginTop: 4 }}
              required
            />
          </label>
        </div>
        <div style={{ marginBottom: 12 }}>
          <label>
            Şifre
            <input
              type="password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              placeholder="••••••"
              style={{ width: '100%', padding: 8, marginTop: 4 }}
              required
            />
          </label>
        </div>
        <button type="submit" disabled={loading} style={{ padding: '8px 12px' }}>
          {loading ? 'Giriş yapılıyor...' : 'Giriş Yap'}
        </button>
      </form>
      {error && <p style={{ color: 'red' }}>{error}</p>}
      {successMsg && <p style={{ color: 'green' }}>{successMsg}</p>}
      {user && (
        <div style={{ marginTop: 12 }}>
          <strong>Kullanıcı:</strong>
          <div>{user.fullName}</div>
          <div>{user.email}</div>
          <div>Rol: {user.role}</div>
        </div>
      )}
    </div>
  );
};