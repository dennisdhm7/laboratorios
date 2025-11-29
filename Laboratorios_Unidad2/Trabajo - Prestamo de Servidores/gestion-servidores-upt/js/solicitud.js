// 🆕 Base simulada de alumnos
const alumnos = {
  "2019065161": "Christian Hinojosa Mucho",
  "2019058742": "Bryan Chite Quispe",
  "2019062418": "Royser Villanueva Mamani",
  "2019059623": "Antony Chata Ramos",
  "2019058777": "Erlang Vilca Condori"
};

// Autocompletar características de servidores
const servidores = {
  Server1: "N° Serie: S001\nTipo: Blade\nCPU: Xeon Silver 4210\nRAM: 64GB\nAlmacenamiento: 2TB SSD",
  Server2: "N° Serie: S002\nTipo: Torre\nCPU: AMD EPYC 7302\nRAM: 128GB\nAlmacenamiento: 4TB HDD",
  Server3: "N° Serie: S003\nTipo: Blade\nCPU: Intel Xeon Gold 6226R\nRAM: 96GB\nAlmacenamiento: 3TB SSD",
  Server4: "N° Serie: S004\nTipo: Torre\nCPU: Ryzen 9 5950X\nRAM: 64GB\nAlmacenamiento: 2TB NVMe"
};

document.getElementById("servidor").addEventListener("change", (e) => {
  const seleccionado = e.target.value;
  document.getElementById("caracteristicas").value = servidores[seleccionado] || "";
});

// Establecer fecha actual por defecto
document.getElementById("fecha").valueAsDate = new Date();

// 🆕 Autocompletar nombre del responsable
const inputCodigoResp = document.getElementById("codigoResponsable");
const inputNombreResp = document.createElement("input");
inputNombreResp.classList.add("form-control", "mt-2");
inputNombreResp.placeholder = "Nombre del responsable";
inputNombreResp.readOnly = true;
inputCodigoResp.insertAdjacentElement("afterend", inputNombreResp);

inputCodigoResp.addEventListener("keyup", () => {
  const codigo = inputCodigoResp.value.trim();
  inputNombreResp.value = alumnos[codigo] || "";
});

// 🧩 Agregar integrantes dinámicamente
const contenedor = document.getElementById("integrantes");
document.getElementById("btnAgregarIntegrante").addEventListener("click", () => {
  const div = document.createElement("div");
  div.classList.add("input-group", "mb-2");
  div.innerHTML = `
    <input type="text" placeholder="Código" class="form-control form-control-sm codigoInt">
    <input type="text" placeholder="Nombre" class="form-control form-control-sm nombreInt" readonly>
    <button type="button" class="btn btn-outline-danger btn-sm eliminar">X</button>
  `;
  contenedor.appendChild(div);

  // 🆕 Autocompletar nombre del integrante
  const codigoInput = div.querySelector(".codigoInt");
  const nombreInput = div.querySelector(".nombreInt");

  codigoInput.addEventListener("keyup", () => {
    const codigo = codigoInput.value.trim();
    nombreInput.value = alumnos[codigo] || "";
  });

  div.querySelector(".eliminar").addEventListener("click", () => div.remove());
});

// Guardar solicitud en localStorage
document.getElementById("formSolicitud").addEventListener("submit", (e) => {
  e.preventDefault();

  const solicitud = {
    id: Date.now(),
    docente: document.getElementById("docente").value,
    curso: document.getElementById("curso").value,
    semestre: document.getElementById("semestre").value,
    fecha: document.getElementById("fecha").value,
    horaInicio: document.getElementById("horaInicio").value,
    horaFin: document.getElementById("horaFin").value,
    servidor: document.getElementById("servidor").value,
    caracteristicas: document.getElementById("caracteristicas").value,
    opcionales: [
      ...(document.getElementById("monitor").checked ? ["Monitor"] : []),
      ...(document.getElementById("teclado").checked ? ["Teclado"] : []),
      ...(document.getElementById("mouse").checked ? ["Mouse"] : [])
    ],
    codigoResponsable: inputCodigoResp.value,
    nombreResponsable: inputNombreResp.value, // 🆕 nuevo campo
    integrantes: Array.from(contenedor.querySelectorAll(".input-group")).map(div => ({
      codigo: div.querySelector(".codigoInt").value,
      nombre: div.querySelector(".nombreInt").value
    })),
    soporte: document.getElementById("soporte").value,
    estado: "Pendiente"
  };

  const solicitudes = JSON.parse(localStorage.getItem("solicitudes") || "[]");
  solicitudes.push(solicitud);
  localStorage.setItem("solicitudes", JSON.stringify(solicitudes));

  alert("✅ Solicitud enviada correctamente.");
  e.target.reset();
  contenedor.innerHTML = "";
  inputNombreResp.value = "";
});
