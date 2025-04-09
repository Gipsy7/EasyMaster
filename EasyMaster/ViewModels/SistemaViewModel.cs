namespace EasyMaster.ViewModels
{
    public class SistemaViewModel
    {
        public int IdSistema { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<ModuloViewModel> Modulos { get; set; }
        public List<PersonagemViewModel> Personagens { get; set; }
    }
}
