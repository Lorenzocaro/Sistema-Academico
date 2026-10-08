import { Pencil, Power, Trash2 } from 'lucide-react';

/**
 * Tarjeta reutilizable para un plan de estudio.
 */
function PlanCard({ plan, onEdit, onToggleStatus, onDelete, onViewSubjects }) {
  const { id, nombre, codigo, añoInicio, añoFin, duracion, modalidad, cargaHoraria, regimen, activo } = plan;

  return (
    <article className="plan-card">
      <div className="plan-card-header">
        <span className={`plan-badge ${activo ? 'plan-badge-active' : 'plan-badge-inactive'}`}>
          {activo ? 'Activo' : 'Archivado'}
        </span>
        <div className="plan-card-actions">
          <button type="button" title="Editar plan" aria-label={`Editar ${nombre}`} onClick={() => onEdit(id)}>
            <Pencil size={16} />
          </button>
          <button type="button" title={activo ? 'Desactivar plan' : 'Activar plan'} aria-label={`${activo ? 'Desactivar' : 'Activar'} ${nombre}`} onClick={() => onToggleStatus(id)}>
            <Power size={17} />
          </button>
          <button className="plan-delete-action" type="button" title="Eliminar plan" aria-label={`Eliminar ${nombre}`} onClick={() => onDelete(id)}>
            <Trash2 size={16} />
          </button>
        </div>
      </div>

      <div className="plan-card-body">
        <span className="plan-card-id">{codigo ?? `PLAN ${String(id).padStart(2, '0')}`} – {nombre}</span>
        <p className="plan-card-years">{añoInicio} - {añoFin}</p>

        <div className="plan-card-details">
          <div className="plan-card-detail">
            <span className="detail-label">Duración</span>
            <span className="detail-value">{duracion ?? '—'}</span>
          </div>
          <div className="plan-card-detail">
            <span className="detail-label">Modalidad</span>
            <span className="detail-value">{modalidad ?? '—'}</span>
          </div>
          <div className="plan-card-detail">
            <span className="detail-label">Carga Horaria</span>
            <span className="detail-value">{cargaHoraria ?? '—'}</span>
          </div>
          <div className="plan-card-detail">
            <span className="detail-label">Régimen de cursado</span>
            <span className="detail-value">{regimen ?? '—'}</span>
          </div>
        </div>
      </div>

      <div className="plan-card-footer">
        <button className="plan-view-button" type="button" onClick={() => onViewSubjects(id)}>
          Ver plan
        </button>
        <button className="plan-archive-button" type="button" onClick={() => onToggleStatus(id)}>
          {activo ? 'Archivar' : 'Restaurar'}
        </button>
      </div>
    </article>
  );
}

export default PlanCard;