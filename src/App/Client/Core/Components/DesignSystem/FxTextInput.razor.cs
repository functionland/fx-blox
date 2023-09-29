using Microsoft.AspNetCore.Components.Web;

namespace Functionland.FxBlox.Client.Core.Components
{
    public partial class FxTextInput
    {
        [Parameter]
        public string? Label { get; set; }

        [Parameter]
        public EventCallback<string?> TextChanged { get; set; }

        [Parameter]
        public EventCallback<bool> IsEnterClicked { get; set; }

        private string? _text { get; set; }
        [Parameter]
        public string? Text
        {
            get { return _text; }
            set
            {
                if (_text == value) return;

                _text = value;
                TextChanged.InvokeAsync(value);
            }
        }

        [Parameter]
        public string? Margin { get; set; }

        [Parameter]
        public string? Placeholder { get; set; }

        [Parameter]
        public string? FieldQuestion { get; set; }

        [Parameter]
        public string? ErrorMessage { get; set; }

        [Parameter]
        public FxTextInputType Type { get; set; } = FxTextInputType.Text;

        private ElementReference _input;

        private Guid InputId { get; set; } = Guid.NewGuid();

        public async Task FocusInputAsync()
        {
            await _input.FocusAsync();
        }
        private async Task HandleOnKeyDownAsync(KeyboardEventArgs e)
        {
            if (e.Key == "Enter")
            {
                await JSRuntime.InvokeVoidAsync("Controller.hideKeyboard", InputId.ToString());
                await IsEnterClicked.InvokeAsync(true);
            }
        }
    }
}