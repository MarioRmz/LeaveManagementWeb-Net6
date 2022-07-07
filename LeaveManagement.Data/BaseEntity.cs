namespace LeaveManagement.Data
{
    //Al ser abstract evita que se pueda instanciar por su cuenta esta clase
    //y solo se tenga acceso a ella y a sus objetos por medio de heredacion
    //Antes era partial, pero esto permitia que la clase pudiera extenderse en otras partes del
    //programa y esa no era la intencion.
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}
