import { ChevronRight } from 'lucide-react';

const tabs = ['Resumen', 'Materias', 'Materias por año', 'Correlatividades'];

function PlanDetalle({ plan, onBack }) {
  return (
    <section className="plan-detalle-page">
      <nav className="plan-detalle-breadcrumb">
        <button type="button" onClick={onBack}>Planes de Estudio</button>
        <ChevronRight size={14} />
        <span>{plan.codigo} – {plan.nombreCorto ?? plan.nombre}</span>
      </nav>

      <div className="plan-detalle-heading">
        <div className="plan-detalle-title">
          <h1>{plan.codigo} – {plan.nombre}</h1>
          <span className={`plan-status-badge ${plan.activo ? 'activo' : 'archivado'}`}>
            {plan.activo ? 'Activo' : 'Archivado'}
          </span>
        </div>
        <div className="plan-detalle-actions">
          <button type="button" className="plan-detalle-secondary-button">Editar</button>
          <button type="button" className="plan-detalle-secondary-button">Archivar</button>
        </div>
      </div>

      <div className="plan-detalle-tabs">
        {tabs.map((tab, index) => (
          <button key={tab} type="button" className={index === 0 ? 'active' : ''}>
            {tab}
          </button>
        ))}
      </div>

      <div className="plan-detalle-card">
        <h2>Información del Plan</h2>
        <div className="plan-detalle-grid">
          <div className="plan-detalle-field">
            <span className="field-label">Nombre del plan</span>
            <span className="field-value">{plan.nombre}</span>
          </div>
          <div className="plan-detalle-field">
            <span className="field-label">Código</span>
            <span className="field-value">{plan.codigo}</span>
          </div>
          <div className="plan-detalle-field">
            <span className="field-label">Año de inicio del plan de estudio</span>
            <span className="field-value">{plan.añoInicio}</span>
          </div>
          <div className="plan-detalle-field">
            <span className="field-label">Año de finalización del plan de estudio</span>
            <span className="field-value">{plan.añoFin}</span>
          </div>
          <div className="plan-detalle-field">
            <span className="field-label">Duración de la carrera</span>
            <span className="field-value">{plan.duracion}</span>
          </div>
          <div className="plan-detalle-field">
            <span className="field-label">Modalidad de la carrera</span>
            <span className="field-value">{plan.modalidad}</span>
          </div>
          <div className="plan-detalle-field">
            <span className="field-label">Carga horaria total</span>
            <span className="field-value">{plan.cargaHoraria}</span>
          </div>
          <div className="plan-detalle-field">
            <span className="field-label">Régimen de cursada</span>
            <span className="field-value">{plan.regimen}</span>
          </div>
        </div>
      </div>
    </section>
  );
}

export default PlanDetalle;