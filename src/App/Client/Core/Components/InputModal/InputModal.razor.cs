

namespace Functionland.FxBlox.Client.Core.Components;

public partial class InputModal
{
    private TaskCompletionSource<InputModalResult>? _tcs;
    private bool _isModalOpen;
    private string? _title;
    private string? _placeholder;
    private string? _inputValue;
    private string? _headTitle;
    private string? _doneBtnText;
    private FxTextInput? _inputRef;
    private string? _label;
    private FxTextInputType _inputType;
    private FxButtonSize _buttonSize;
    private bool _inLineBtn;

    public async Task<InputModalResult> ShowAsync(string title, string headTitle, string inputValue, string placeholder, string? doneBtnText = null, string? label = null, FxTextInputType inputType = FxTextInputType.Text,FxButtonSize buttonSize = FxButtonSize.Stretch,bool inLineBtn = false)
    {
        GoBackService.SetState((Task () =>
        {
            Close();
            StateHasChanged();
            return Task.CompletedTask;
        }), true, false);

        _headTitle = headTitle;
        _inputValue = inputValue;
        _title = title;
        _placeholder = placeholder;
        _doneBtnText = doneBtnText ?? "Submit";
        _label = label ?? "Name";
        _inputType = inputType;
        _buttonSize = buttonSize;
        _inLineBtn = inLineBtn;

        _tcs?.SetCanceled();
        _isModalOpen = true;
        StateHasChanged();

        var timer = new System.Timers.Timer(700);
        timer.Elapsed += TimerElapsed;
        timer.Enabled = true;
        timer.Start();

        _tcs = new TaskCompletionSource<InputModalResult>();

        InputModalResult result;

        try
        {
            result = await _tcs.Task;
        }
        catch (TaskCanceledException)
        {
            result = new InputModalResult
            {
                ResultType = InputModalResultType.Cancel
            };
        }

        GoBackService.ResetToPreviousState();

        return result;
    }

    private void TimerElapsed(object? sender, System.Timers.ElapsedEventArgs e)
    {
        InvokeAsync(async () =>
        {
            if (_inputRef is not null)
            {
                await _inputRef.FocusInputAsync();
            }
        });

        var timer = (System.Timers.Timer)sender;
        timer.Elapsed -= TimerElapsed;
        timer.Enabled = false;
        timer.Stop();

        timer.Dispose();
    }

    private void Close()
    {
        var result = new InputModalResult
        {
            ResultType = InputModalResultType.Cancel
        };

        try
        {
            _tcs?.SetResult(result);
        }
        finally
        {
            _tcs = null;

            _isModalOpen = false;
        }

    }

    private void Confirm()
    {
        var result = new InputModalResult
        {
            ResultType = InputModalResultType.Confirm,
            Result = _inputValue
        };

        try
        {
            _tcs?.SetResult(result);
        }
        finally
        {
            _tcs = null;

            _isModalOpen = false;
        }
    }

    public void OnHandelEnterClick(bool isEnterClicked)
    {
        if (isEnterClicked)
        {
            Confirm();
        }
    }

    public void Dispose()
    {
        _tcs?.SetCanceled();
    }
}