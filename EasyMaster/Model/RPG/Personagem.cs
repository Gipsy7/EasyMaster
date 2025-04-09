namespace EasyMaster.Model.RPG
{
    public class Personagem
    {
        public int IdPersonagem { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Lore { get; set; }
        public virtual ICollection<Modulo> Modulos { get; set; }
        public int IdSistema { get; set; }
        public virtual Sistema Sistema { get; set; }
    }
}
