# NativApps - Product Management API

¡Bienvenido a NativApps!

![NativApps Logo](insertar-enlace-a-imagen)

NativApps es una API diseñada para evaluar y mejorar las habilidades de desarrollo de aplicaciones .NET backend. Ofrece operaciones CRUD para usuarios y productos, junto con características de seguridad para garantizar un entorno robusto y seguro.

## 📋 Tabla de Contenidos

- [🚀 Uso](#uso)
- [⚙️ Instalación](#instalación)
- [📝 Documentación](#documentación)
- [📞 Contacto](#contacto)

## 🚀 Uso

- La API está desplegada en un ambiente temporal de desarrollo y puede acceder a ella mediante el siguiente [enlace](http://nativapps.somee.com/swagger/index.html).
- La documentación generada por Postman la encontrará [aquí](https://documenter.getpostman.com/view/6754077/2sA3JRYe9u).
- Para autenticarse en la API, utilice los siguientes usuarios:
    - Usuario: adolfojinete - Contraseña: qwerty789 (Administrador)
    - Usuario: pepitoperez - Contraseña: qwerty789 (Usuario)
- Para crear un nuevo producto, el Id de la categoría es: `4B58D46B-E156-4FEB-9D8C-A7C5AC8B914C`.

## ⚙️ Instalación

Si desea ejecutar la prueba en su localhost, siga los siguientes pasos:

1. Clone el repositorio:

    ```bash
    git clone https://github.com/lookatmee/NativApps.git
    ```

2. Abra la solución en Visual Studio.

3. Abra la Consola del Administrador de paquetes e ingrese al proyecto `NativApps.Products.Data`.

4. Ejecute el siguiente comando para crear la base de datos:

    ```bash
    update-database
    ```

5. Ejecuta los siguientes scripts SQL en la base de datos de Products:

    ```sql
    insert into Categories values (NEWID(), 'Electrodomesticos', 'Nevera, Lavadoras');
    insert into Roles values (NEWID(), 'Admin');
    insert into Roles Values (NEWID(), 'Usuario');
    insert into Users Values ('adolfojinete', (select RolId from Roles where Name = 'Admin'), 'qwerty789');
    insert into Users Values ('pepitoperez', (select RolId from Roles where Name = 'Usuario'), 'qwerty789');
    ```

6. ¡Listo para su ejecución!

## 📝 Documentación

Encuentre más detalles sobre el uso de la API en nuestra [documentación](https://documenter.getpostman.com/view/6754077/2sA3JRYe9u).

## 📞 Contacto

Para cualquier pregunta o sugerencia, no dude en contactarnos en [adolfojinete@hotmail.com](mailto:adolfojinete@hotmail.com).
