﻿using System;
using System.Collections.Generic;

namespace ProyectoBBDD.Models;

public partial class Usuarios
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public int Idrol { get; set; }

    public string Correo { get; set; } = null!;

    public virtual Roles IdrolNavigation { get; set; } = null!;

    public virtual ICollection<Registrocompras> Registrocompras { get; set; } = new List<Registrocompras>();
}
