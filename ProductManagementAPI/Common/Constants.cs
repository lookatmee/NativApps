namespace ProductManagementAPI.Common;

/// <summary>
/// Clase estática que contiene constantes para mensajes de error comunes.
/// </summary>
public static class Constants
{
    /// <summary>
    /// Estructura que define los mensajes de error.
    /// </summary>
    public struct ErrorMessages
    {
        public const string GetAllProductsError = "Error al obtener todos los productos.";
        public const string GetProductByIdError = "Error al obtener el producto con ID {0}.";
        public const string AddProductError = "Error al agregar el producto.";
        public const string UpdateProductError = "Error al actualizar el producto con ID {0}.";
        public const string DeleteProductError = "Error al eliminar el producto con ID {0}.";
        public const string SearchProductsError = "Error al buscar productos.";
        public const string SearchUserError = "Error al buscar el usuario.";
        public const string UserNull = "Intento de inicio de sesión con usuario nulo.";
        public const string InvalidClientRequest = "Solicitud de cliente no válida.";
        public const string InvalidCredentials = "Credenciales inválidas.";
        public const string InternalServerError = "Error interno del servidor.";
    }
}
