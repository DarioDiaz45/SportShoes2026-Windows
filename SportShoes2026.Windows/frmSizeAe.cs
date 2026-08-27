using SportShoes2026.Service.DTOs.Brand;
using SportShoes2026.Service.DTOs.Size;
using SportShoes2026.Service.DTOs.Sport;
using SportShoes2026.Service.Interfaces;
using SportShoes2026.Windows.Helpers;

namespace SportShoes2026.Windows
{
    public partial class frmSizeAe : Form
    {
        private SizeUpdateDto? _sizeUpdateDto;
        private readonly ISizeService _sizeServicio;
        private bool _esEdicion = false;
        public frmSizeAe(ISizeService brandServicio)
        {
            InitializeComponent();
            _sizeServicio = brandServicio;
        }
        public int UltimoId { get; private set; }
        public bool DataChanged { get; private set; }
        public bool ConcurrencyConflict { get; private set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (_sizeUpdateDto is null)
            {
                chkActiveSize.Checked = true;
                chkActiveSize.Enabled = false;

            }
            else
            {
                nudNumberSize.Value = _sizeUpdateDto.Number;

                chkActiveSize.Checked = _sizeUpdateDto.IsActive;
                chkActiveSize.Enabled = true;
                _esEdicion = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
             if (ValidarDatos())
            {
                try
                {
                    if (!_esEdicion)
                    {

                        var _sizeCreateDto = new SizeCreateDto();
                        _sizeCreateDto.Number = nudNumberSize.Value;
                        
                        var resultadoAgregar = _sizeServicio.Add(_sizeCreateDto);
                        if (resultadoAgregar.IsFailure)
                        {
                            ErrorHelper.MostrarErrores(resultadoAgregar.Errors);
                            return;
                        }
                        DataChanged = true;
                        UltimoId = resultadoAgregar.Value;
                        var respuestaAgregarOtro = MessageBox.Show("Registro agregado\n¿Desea agregar otro?",
                                "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button2);
                        if (respuestaAgregarOtro == DialogResult.No)
                        {
                            DialogResult = DialogResult.OK;
                        }
                        InicializarControles();

                    }
                    else
                    {
                        if (_sizeUpdateDto is null)
                        {
                            _sizeUpdateDto = new SizeUpdateDto();
                        }
                        _sizeUpdateDto.Number = nudNumberSize.Value;
                        _sizeUpdateDto.IsActive = chkActiveSize.Checked;
                        _sizeUpdateDto.SizeId = _sizeUpdateDto.SizeId;

                        var resultadoEditar = _sizeServicio
                            .Update(_sizeUpdateDto);
                        if (resultadoEditar.IsConcurrencyConflict)
                        {
                            ErrorHelper.MostrarErrores(resultadoEditar.Errors);

                            ConcurrencyConflict = true;
                            DialogResult = DialogResult.Cancel;

                            Close();
                            return;
                        }
                        if (resultadoEditar.IsFailure)
                        {
                            ErrorHelper.MostrarErrores(resultadoEditar.Errors);
                            return;
                        }
                        DataChanged = true;
                        MessageBox.Show("Registro editado satisfactoriamente",
                            "Mensaje",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void InicializarControles()
        {
            nudNumberSize.Value = 0;
            chkActiveSize.Checked = true;
            chkActiveSize.Enabled = false;
            nudNumberSize.Focus();
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(nudNumberSize.Text))
            {
                valido = false;
                errorProvider1.SetError(nudNumberSize, "El nombre es requerido");

            }
            return valido;
        }
        public void SetSize(SizeUpdateDto? sizeEditDto)
        {
            _sizeUpdateDto = sizeEditDto;
        }

        internal SizeUpdateDto? GetSize()
        {
            return _sizeUpdateDto;
        }
    }
    
}
