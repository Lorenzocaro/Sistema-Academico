const esperar = (milisegundos = 400) => new Promise((resolve) => setTimeout(resolve, milisegundos));

const PLANTILLAS = [
  { eventType: 'LOGIN_EXITOSO', result: 'EXITO', userEmail: 'fernando@uni.edu', resource: 'POST /api/auth/login', reason: null, ipAddress: '10.0.0.21' },
  { eventType: 'LOGIN_EXITOSO', result: 'EXITO', userEmail: 'esteban@uni.edu', resource: 'POST /api/auth/login', reason: null, ipAddress: '10.0.0.34' },
  { eventType: 'LOGIN_FALLIDO', result: 'FALLIDO', userEmail: 'esteban@uni.edu', resource: 'POST /api/auth/login', reason: 'CREDENCIALES_INVALIDAS', ipAddress: '10.0.0.34' },
  { eventType: 'LOGIN_FALLIDO', result: 'FALLIDO', userEmail: null, resource: 'POST /api/auth/login', reason: 'CREDENCIALES_INVALIDAS', ipAddress: '10.0.0.58' },
  { eventType: 'ACCESO_DENEGADO', result: 'DENEGADO', userEmail: 'esteban@uni.edu', resource: 'GET /api/users', reason: 'SIN_PERMISO', ipAddress: '10.0.0.34' },
  { eventType: 'CUENTA_BLOQUEADA', result: 'FALLIDO', userEmail: 'esteban@uni.edu', resource: 'POST /api/auth/login', reason: 'BLOQUEO_POR_INTENTOS', ipAddress: '10.0.0.34' },
];

const AHORA = Date.now();
const EVENTOS = Array.from({ length: 42 }, (_, indice) => ({
  id: 1000 - indice,
  occurredAt: new Date(AHORA - indice * 37 * 60 * 1000).toISOString(),
  userId: null,
  ...PLANTILLAS[indice % PLANTILLAS.length],
}));

export const auditService = {
  listar: async ({ desde, hasta, usuario, evento, resultado, pagina = 1, tamano = 10 } = {}) => {
    await esperar();

    let items = EVENTOS;
    if (desde) items = items.filter((e) => e.occurredAt >= new Date(`${desde}T00:00:00`).toISOString());
    if (hasta) items = items.filter((e) => e.occurredAt <= new Date(`${hasta}T23:59:59`).toISOString());
    if (usuario) items = items.filter((e) => (e.userEmail ?? '').toLowerCase().includes(usuario.trim().toLowerCase()));
    if (evento) items = items.filter((e) => e.eventType === evento);
    if (resultado) items = items.filter((e) => e.result === resultado);

    const inicio = (pagina - 1) * tamano;
    return { items: items.slice(inicio, inicio + tamano), total: items.length, page: pagina, pageSize: tamano };
  },
};