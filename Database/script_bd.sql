-- Crear la base de datos
CREATE DATABASE AgendaContactos;
GO
-- Usar la base de datos
USE AgendaContactos;
GO
-- Crear la tabla Contactos
CREATE TABLE Contactos (
    IdContacto INT IDENTITY(1,1) PRIMARY KEY, -- Clave primaria auto-incremental
    Nombre NVARCHAR(50) NOT NULL,            -- Nombre del contacto
    Apellido NVARCHAR(50) NOT NULL,          -- Apellido del contacto
    Telefono NVARCHAR(15) NOT NULL,          -- Teléfono del contacto
    Email NVARCHAR(100) NOT NULL             -- Correo electrónico del contacto
);
GO
-- Agregar datos iniciales de prueba (opcional)
INSERT INTO Contactos (Nombre, Apellido, Telefono, Email)
VALUES
    ('Juan', 'Pérez', '1234567890', 'juan.perez@example.com'),
    ('Ana', 'Martínez', '0987654321', 'ana.martinez@example.com'),
    ('Carlos', 'Gómez', '1122334455', 'carlos.gomez@example.com');
