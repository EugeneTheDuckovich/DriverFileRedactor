using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace spz_cource_proj_src.Models;

public class MainModel
{
    private string _fileText;
    public string FileText 
    {
        get => _fileText;
        set 
        {
            _fileText = value;
            IsFileSaved = false;
        } 
    }

    public string CurrentPath { get; private set; }

    public bool IsFileSaved { get; private set; }

    public MainModel()
    {
        _fileText = string.Empty;
        CurrentPath = string.Empty;
        IsFileSaved = true;
    }

    public bool OpenFile(string pathToFile)
    {
        if (string.IsNullOrEmpty(pathToFile))
        {
            MessageBox.Show("input path!");
            return false;
        }

        if (!File.Exists(pathToFile))
        {
            MessageBox.Show("file does not exist!");
            return false;
        }

        //if (!pathToFile.EndsWith(".inf")) 
        //{
        //    MessageBox.Show("invalid file extention!");
        //    return; 
        //}

        if (!IsFileSaved)
        {
            var dialogResult = MessageBox.Show("you have unsaved changes. do you want to save them now?",
                "",MessageBoxButton.YesNoCancel);

            if (dialogResult == MessageBoxResult.Cancel) return false;

            if (dialogResult == MessageBoxResult.Yes) SaveFile();
        }

        FileText = File.ReadAllText(pathToFile);
        CurrentPath = pathToFile;
        IsFileSaved = true;
        return true;
    }

    public void SaveFile()
    {
        if (string.IsNullOrEmpty(CurrentPath) || !File.Exists(CurrentPath))
        {
            MessageBox.Show("nothing to save!");
            return;
        }

        File.WriteAllText(CurrentPath, FileText);

        IsFileSaved = true;
    }
}
