let modalDetalleReporte;

document.addEventListener("DOMContentLoaded", () => {
  modalDetalleReporte = new bootstrap.Modal(document.getElementById("modalDetalleReporte"));

  const solicitudes = JSON.parse(localStorage.getItem("solicitudes") || "[]");
  actualizarResumen(solicitudes);
  renderTabla(solicitudes);

  // Aplicar filtros
  document.getElementById("btnFiltrar").addEventListener("click", () => {
    const sem = document.getElementById("f-semestre").value;
    const est = document.getElementById("f-estado").value;

    let filtradas = solicitudes;
    if (sem !== "todos") filtradas = filtradas.filter(s => s.semestre === sem);
    if (est !== "todos") filtradas = filtradas.filter(s => s.estado === est);

    actualizarResumen(filtradas);
    renderTabla(filtradas);
  });

  // Limpiar filtros
  document.getElementById("btnLimpiar").addEventListener("click", () => {
    document.getElementById("f-semestre").value = "todos";
    document.getElementById("f-estado").value = "todos";
    actualizarResumen(solicitudes);
    renderTabla(solicitudes);
  });
});

// 🔹 Resumen de totales
function actualizarResumen(data) {
  document.getElementById("r-total").textContent = data.length;
  document.getElementById("r-pendientes").textContent = data.filter(s => s.estado === "Pendiente").length;
  document.getElementById("r-aprobadas").textContent = data.filter(s => s.estado === "Aprobado").length;
  document.getElementById("r-rechazadas").textContent = data.filter(s => s.estado === "Rechazado").length;
}

// 🔹 Renderizar tabla con columna de Detalles
function renderTabla(data) {
  const tbody = document.getElementById("tablaReportes");

  if (data.length === 0) {
    tbody.innerHTML = `<tr><td colspan="8" class="text-center text-muted py-3">No hay solicitudes para mostrar</td></tr>`;
    return;
  }

  tbody.innerHTML = "";
  data.forEach((s) => {
    const tr = document.createElement("tr");
    tr.innerHTML = `
      <td>${s.id}</td>
      <td>${s.semestre}</td>
      <td>${s.docente}</td>
      <td>${s.curso}</td>
      <td>${s.fecha}</td>
      <td>${s.servidor}</td>
      <td class="text-center">
        <span class="badge rounded-pill bg-${s.estado === "Aprobado" ? "success" : s.estado === "Rechazado" ? "danger" : "warning"} fs-6 px-3">
          ${s.estado}
        </span>
      </td>
      <td class="text-center">
        <button class="btn btn-sm btn-info text-white detalles"><i class="bi bi-eye"></i> Detalles</button>
      </td>
    `;
    tbody.appendChild(tr);
    tr.querySelector(".detalles").addEventListener("click", () => mostrarDetalleReporte(s));
  });
}

// 🔹 Mostrar detalles en modal
function mostrarDetalleReporte(s) {
  const div = document.getElementById("detalleReporteContenido");
  div.innerHTML = `
    <p><strong>Docente:</strong> ${s.docente}</p>
    <p><strong>Curso:</strong> ${s.curso}</p>
    <p><strong>Semestre:</strong> ${s.semestre}</p>
    <p><strong>Fecha:</strong> ${s.fecha} (${s.horaInicio} - ${s.horaFin})</p>
    <p><strong>Servidor:</strong> ${s.servidor}</p>
    <pre class="bg-light p-2">${s.caracteristicas}</pre>
    <p><strong>Responsable:</strong> ${s.codigoResponsable} - ${s.nombreResponsable || ''}</p>
    <p><strong>Integrantes:</strong></p>
    <ul>${s.integrantes.map(i => `<li>${i.codigo} - ${i.nombre}</li>`).join("")}</ul>
    <p><strong>Opcionales:</strong> ${s.opcionales.join(", ") || "Ninguno"}</p>
    <p><strong>Soporte asignado:</strong> ${s.soporte}</p>
    <p><strong>Estado:</strong> ${s.estado}</p>
    ${s.atendidoPor ? `<p><strong>Atendido por:</strong> ${s.atendidoPor}</p>` : ""}
    ${s.motivo ? `<p class="text-danger"><strong>Motivo del rechazo:</strong> ${s.motivo}</p>` : ""}
  `;
  modalDetalleReporte.show();
}
