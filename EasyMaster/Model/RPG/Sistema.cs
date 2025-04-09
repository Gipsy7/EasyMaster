namespace EasyMaster.Model.RPG
{
    public class Sistema
    {
        public int IdSistema { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<Modulo> Modulos { get; set; }
        public virtual ICollection<Personagem> Personagens { get; set; }
    }
}
