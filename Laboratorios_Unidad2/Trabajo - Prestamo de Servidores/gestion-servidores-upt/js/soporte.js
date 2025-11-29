let modalDetalles, modalAprobar, modalRechazar;

document.addEventListener("DOMContentLoaded", () => {
  modalDetalles = new bootstrap.Modal(document.getElementById("modalDetalles"));
  modalAprobar = new bootstrap.Modal(document.getElementById("modalAprobar"));
  modalRechazar = new bootstrap.Modal(document.getElementById("modalRechazar"));
  cargarSolicitudes();
});

function cargarSolicitudes() {
  const solicitudes = JSON.parse(localStorage.getItem("solicitudes") || "[]");

  // 🔸 Filtrar solo las solicitudes pendientes
  const pendientes = solicitudes.filter(s => s.estado === "Pendiente");

  const tbody = document.getElementById("tablaSolicitudes");
  tbody.innerHTML = "";

  if (pendientes.length === 0) {
    tbody.innerHTML = `
      <tr>
        <td colspan="8" class="text-center text-muted py-3">
          <i class="bi bi-inbox"></i> No hay solicitudes pendientes por revisar.
        </td>
      </tr>
    `;
  }

  pendientes.forEach((s) => {
    const tr = document.createElement("tr");
    tr.innerHTML = `
      <td class="text-center">${s.id}</td>
      <td>${s.docente}</td>
      <td>${s.curso}</td>
      <td class="text-center">${s.semestre}</td>
      <td class="text-center">${s.fecha}</td>
      <td class="text-center">${s.servidor}</td>
      <td class="text-center">
        <span class="badge rounded-pill fs-6 px-3 bg-warning text-dark">Pendiente</span>
      </td>
      <td class="text-center">
        <button class="btn btn-sm btn-info text-white me-1 detalles">
          <i class="bi bi-eye"></i> Detalles
        </button>
        <button class="btn btn-sm btn-success me-1 aprobar">
          <i class="bi bi-check-lg"></i> Aprobar
        </button>
        <button class="btn btn-sm btn-danger rechazar">
          <i class="bi bi-x-lg"></i> Rechazar
        </button>
      </td>
    `;
    tbody.appendChild(tr);

    tr.querySelector(".detalles").addEventListener("click", () => mostrarDetalles(s));
    tr.querySelector(".aprobar").addEventListener("click", () => abrirModalAprobacion(s.id));
    tr.querySelector(".rechazar").addEventListener("click", () => abrirModalRechazo(s.id));
  });

  // 🔸 Actualizar contadores con los datos totales
  actualizarResumen(solicitudes);
}

function mostrarDetalles(s) {
  const div = document.getElementById("detalleContenido");
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
    <p><strong>Estado actual:</strong> ${s.estado}</p>
    ${s.motivo ? `<p class="text-danger"><strong>Motivo del rechazo:</strong> ${s.motivo}</p>` : ""}
  `;
  modalDetalles.show();
}

function abrirModalAprobacion(id) {
  document.getElementById("idAprobar").value = id;
  modalAprobar.show();
}

function abrirModalRechazo(id) {
  document.getElementById("idRechazar").value = id;
  document.getElementById("motivoRechazo").value = "";
  modalRechazar.show();
}

document.getElementById("btnConfirmarAprobacion").addEventListener("click", () => {
  const id = parseInt(document.getElementById("idAprobar").value);
  const soporte = document.getElementById("soporteAprobador").value;
  cambiarEstado(id, "Aprobado", soporte);
  modalAprobar.hide();
});

document.getElementById("btnConfirmarRechazo").addEventListener("click", () => {
  const id = parseInt(document.getElementById("idRechazar").value);
  const soporte = document.getElementById("soporteRechazador").value;
  const motivo = document.getElementById("motivoRechazo").value.trim();
  if (!motivo) return alert("⚠️ Debe ingresar un motivo de rechazo.");
  cambiarEstado(id, "Rechazado", soporte, motivo);
  modalRechazar.hide();
});

function cambiarEstado(id, nuevoEstado, soporteAutor, motivo = null) {
  const solicitudes = JSON.parse(localStorage.getItem("solicitudes") || "[]");
  const index = solicitudes.findIndex(s => s.id === id);
  if (index !== -1) {
    solicitudes[index].estado = nuevoEstado;
    solicitudes[index].atendidoPor = soporteAutor;
    if (motivo) solicitudes[index].motivo = motivo;
    localStorage.setItem("solicitudes", JSON.stringify(solicitudes));
    cargarSolicitudes();
  }
}

function actualizarResumen(solicitudes) {
  document.getElementById("totalSolicitudes").textContent = solicitudes.length;
  document.getElementById("pendientes").textContent = solicitudes.filter(s => s.estado === "Pendiente").length;
  document.getElementById("aprobadas").textContent = solicitudes.filter(s => s.estado === "Aprobado").length;
  document.getElementById("rechazadas").textContent = solicitudes.filter(s => s.estado === "Rechazado").length;
}
