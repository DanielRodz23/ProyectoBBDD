using System;
using System.Collections.Generic;

namespace ProyectoBBDD.Models;

public partial class Registrocompras
{
    public int Id { get; set; }

    public int IdUsuario { get; set; }

    public int IdProducto { get; set; }

    public int Cantidad { get; set; }

    public virtual Productos IdProductoNavigation { get; set; } = null!;

    public virtual Usuarios IdUsuarioNavigation { get; set; } = null!;
}
