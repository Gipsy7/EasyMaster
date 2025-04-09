using EasyMaster.Model.RPG.Enums;

namespace EasyMaster.Model.RPG
{
    public class Componente
    {
        public int IdComponente { get; set; }
        public int IdModulo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal valor { get; set; }
        public virtual Modulo Modulo { get; set; }
    }
}
