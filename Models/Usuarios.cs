using System;
using System.Collections.Generic;

namespace ProyectoBBDD.Models;

public partial class Usuarios
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public int Idrol { get; set; }

    public virtual ICollection<Carrito> Carrito { get; set; } = new List<Carrito>();

    public virtual Roles IdrolNavigation { get; set; } = null!;
}
