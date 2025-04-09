using EasyMaster.Model.RPG.Enums;

namespace EasyMaster.Model.RPG
{
    public class Modulo
    {
        public int IdModulo { get; set; }
        public string Nome { get; set; }
        public ETipoModulo Tipo { get; set; }
        public virtual ICollection<Componente> Componentes { get; set; }
        public int IdSistema { get; set; }
        public virtual Sistema Sistema { get; set; }
    }
}
