using System;
using System.Collections.Generic;

namespace ProyectoBBDD.Models;

public partial class Productos
{
    public int Id { get; set; }

    public int Sku { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Precio { get; set; }

    public string Descripcion { get; set; } = null!;

    public int Stock { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<Carrito> Carrito { get; set; } = new List<Carrito>();
}
