using System;
using System.Collections.Generic;

namespace ProyectoBBDD.Models;

public partial class Productos
{
    public int Id { get; set; }

    public int Sku { get; set; }

    public string Nombre { get; set; } = null!;

    public double Precio { get; set; }

    public string Descripcion { get; set; } = null!;

    public int Stock { get; set; }

    public ulong Estado { get; set; }

    public string Imagen { get; set; } = null!;

    public virtual ICollection<Registrocompras> Registrocompras { get; set; } = new List<Registrocompras>();
}
