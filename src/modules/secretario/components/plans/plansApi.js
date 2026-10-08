import { createMockRepository } from '../../../../api/createMockRepository';

const initialPlans = [
  {
    id: 1,
    nombre: 'Tecnicatura en Desarrollo de Software',
    codigo: 'PE01',
    añoInicio: 2022,
    añoFin: 2030,
    duracion: '3 años',
    modalidad: 'Presencial',
    cargaHoraria: '1623 horas reloj',
    regimen: 'Anual / Cuatrimestral',
    activo: true,
  },
  {
    id: 2,
    nombre: 'Licenciatura en Desarrollo de Software',
    codigo: 'PE02',
    añoInicio: 2025,
    añoFin: 2032,
    duracion: '5 años',
    modalidad: 'Presencial',
    cargaHoraria: '2603 horas reloj',
    regimen: 'Anual / Cuatrimestral',
    activo: true,
  },
  {
    id: 3,
    nombre: 'Tecnicatura en Desarrollo de Software',
    codigo: 'PE03',
    añoInicio: 2018,
    añoFin: 2022,
    duracion: '3 años',
    modalidad: 'Presencial',
    cargaHoraria: '1600 horas reloj',
    regimen: 'Anual / Cuatrimestral',
    activo: false,
  },
];

const mockRepository = createMockRepository(initialPlans);

export const plansApi = {
  obtenerPlanes: async () => mockRepository.list(),
  crearPlan: async (plan) => mockRepository.create(plan),
  actualizarPlan: async (id, plan) => mockRepository.update(id, plan),
  eliminarPlan: async (id) => mockRepository.remove(id),
};
