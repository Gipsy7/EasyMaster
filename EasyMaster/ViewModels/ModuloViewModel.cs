using EasyMaster.Model.RPG.Enums;

namespace EasyMaster.ViewModels
{
    public class ModuloViewModel
    {
        public int IdModulo { get; set; }
        public string Nome { get; set; }
        public ETipoModulo Tipo { get; set; }
        public List<ComponenteViewModel> Componentes { get; set; }
        public int IdSistema { get; set; }
    }
}
