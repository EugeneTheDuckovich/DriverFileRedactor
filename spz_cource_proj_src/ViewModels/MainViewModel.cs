using Microsoft.Win32;
using spz_cource_proj_src.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace spz_cource_proj_src.ViewModels;

public class MainViewModel : NotifyPropertyChanged
{
    private Frame _mainFrame;
    private MainModel _mainModel;

    public MainViewModel(Frame mainFrame)
    {
        _mainFrame = mainFrame;
        _mainModel = new MainModel();
        _pathToFile = string.Empty;
    }

    public string FileText
    {
        get => _mainModel.FileText;
        set
        {
            _mainModel.FileText = value;
            OnPropertyChanged(nameof(FileText));
        }
    }

    public string CurrentPath
    {
        get => _mainModel.CurrentPath;
    }

    private string _pathToFile;
    public string PathToFile
    {
        get => _pathToFile;
        set
        {
            _pathToFile = value;
            OnPropertyChanged(nameof(PathToFile));
        }
    }
    public bool OpenFile()
    {
        var result = _mainModel.OpenFile(PathToFile);
        OnPropertyChanged(nameof(CurrentPath));
        OnPropertyChanged(nameof(FileText));
        return result;
    }

    public ICommand SaveFileCommand => new RelayCommand(parameter =>
    {
        _mainModel.SaveFile();
    });

    public ICommand BrowseFileCommand => new RelayCommand(parameter =>
    {
        var fileDialog = new OpenFileDialog();
        fileDialog.Filter = "Setup information files (*.inf)|*.inf";

        if (fileDialog.ShowDialog() == true)
        {
            PathToFile = fileDialog.FileName;
            if (!OpenFile())
            {
                PathToFile = CurrentPath;
            }
        }

    });

}
