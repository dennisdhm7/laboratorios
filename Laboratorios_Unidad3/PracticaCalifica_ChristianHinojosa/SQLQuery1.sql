
CREATE DATABASE ConsejeriaDB;
GO

USE ConsejeriaDB;USE ConsejeriaDB;
GO

-- ================================================
--  TABLA: Usuarios (solo docentes hacen login)
-- ================================================
CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Correo NVARCHAR(150) NOT NULL UNIQUE,
    Password NVARCHAR(200) NOT NULL,
    Rol NVARCHAR(50) NOT NULL DEFAULT 'docente'
);
GO

-- ================================================
--  TABLA: Docentes
-- ================================================
CREATE TABLE Docentes (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombres NVARCHAR(150) NOT NULL,
    Apellidos NVARCHAR(150) NOT NULL,
    CorreoCorporativo NVARCHAR(150) NOT NULL UNIQUE,
    Activo BIT NOT NULL DEFAULT 1
);
GO

-- ================================================
--  TABLA: Estudiantes (NO tienen login)
-- ================================================
CREATE TABLE Estudiantes (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Codigo NVARCHAR(20) NOT NULL UNIQUE,
    Apellidos NVARCHAR(150) NOT NULL,
    Nombres NVARCHAR(150) NOT NULL,
    Semestre NVARCHAR(20) NULL,  -- Opcional según práctica
    Correo NVARCHAR(150) NULL,
    Activo BIT NOT NULL DEFAULT 1
);
GO

-- ================================================
--  TABLA: Atenciones (registradas por DOCENTES a ESTUDIANTES)
-- ================================================
CREATE TABLE Atenciones (
    Id INT PRIMARY KEY IDENTITY(1,1),

    Semestre NVARCHAR(20) NOT NULL,
    FechaAtencion DATETIME NOT NULL,

    DocenteId INT NOT NULL,
    EstudianteId INT NOT NULL,

    Tema NVARCHAR(200) NOT NULL,
    Consulta NVARCHAR(MAX) NOT NULL,
    Descripcion NVARCHAR(MAX) NOT NULL,
    Evidencia NVARCHAR(MAX) NULL,

    FOREIGN KEY (DocenteId) REFERENCES Docentes(Id),
    FOREIGN KEY (EstudianteId) REFERENCES Estudiantes(Id)
);
GO

-- ================================================
--  INSERTAR DOCENTES (para login y registro)
-- ================================================
INSERT INTO Docentes (Nombres, Apellidos, CorreoCorporativo)
VALUES
('Enrique Félix', 'Lanchipa Valencia', 'elanchipa@upt.pe'),
('Julio César', 'Huanca Tito', 'jhuancat@upt.pe'),
('Kenji', 'Mamani Soto', 'kmamani@upt.pe');
GO

-- ================================================
--  INSERTAR USUARIOS (LOGIN REAL)
-- ================================================
INSERT INTO Usuarios (Correo, Password, Rol)
VALUES
('elanchipa@upt.pe', '123456', 'docente'),
('jhuancat@upt.pe', '123456', 'docente'),
('kmamani@upt.pe', '123456', 'docente'),
('admin@upt.pe', 'admin123', 'admin'); -- opcional
GO

-- ================================================
--  INSERTAR ESTUDIANTES (solo lista, sin login)
-- ================================================
INSERT INTO Estudiantes (Codigo, Apellidos, Nombres, Semestre, Correo)
VALUES
('202012345', 'Hinojosa Mucho', 'Christian Dennis', '2025-I', 'dennis.hinojosa@virtual.upt.pe'),
('202045678', 'Lopez Flores', 'María Fernanda', '2025-I', 'maria.flores@virtual.upt.pe'),
('202078910', 'Quispe Mamani', 'José Luis', '2025-I', 'jose.quispe@virtual.upt.pe'),
('202011223', 'Cárdenas Ramos', 'Lucía Antonella', '2025-I', 'lucia.cardenas@virtual.upt.pe');
GO

-- ================================================
--  INSERTAR ATENCIONES DE EJEMPLO
-- ================================================
INSERT INTO Atenciones (Semestre, FechaAtencion, DocenteId, EstudianteId, Tema, Consulta, Descripcion, Evidencia)
VALUES
('2025-I', '2025-03-12 10:30', 1, 1,
 'Plan de estudios',
 'Deseo saber qué cursos debo llevar para completar mi ciclo.',
 'Se revisó el plan curricular y se sugirió matrícula semipresencial.',
 'El estudiante mostró interés en completar su plan en menos tiempo.'),

('2025-I', '2025-03-14 11:00', 2, 2,
 'Desarrollo profesional',
 'Cómo mejorar mi CV para prácticas pre profesionales.',
 'Se recomendó mejorar formato, incluir logros y LinkedIn.',
 'Se adjuntaron ejemplos de CV.'),

('2025-I', '2025-03-15 09:00', 1, 3,
 'Plan de tesis / tesis',
 '¿Cómo puedo comenzar mi tema de tesis?',
 'Se explicó estructura general, objetivos y viabilidad.',
 'El estudiante se comprometió a traer un borrador.'),

('2025-I', '2025-03-20 15:00', 3, 4,
 'Inserción laboral',
 'Cómo conseguir prácticas en empresas de TI en Tacna.',
 'Se recomendaron empresas tecnológicas y portales de empleo.',
 'El estudiante mostró interés en mejorar habilidades blandas.');
GO