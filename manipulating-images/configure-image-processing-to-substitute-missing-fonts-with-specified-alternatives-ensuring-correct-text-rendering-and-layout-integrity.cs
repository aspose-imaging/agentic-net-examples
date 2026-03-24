using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.CustomFontHandler;

class Program
{
    // Hardcoded paths
    private const string InputPath = @"C:\Images\input.psd";
    private const string OutputPath = @"C:\Images\output.png";
    private const string AlternativeFontsFolder = @"C:\Fonts\Alternatives";

    static void Main()
    {
        // Verify input file exists
        if (!File.Exists(InputPath))
        {
            Console.Error.WriteLine($"File not found: {InputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(OutputPath));

        // Configure Aspose.Imaging to use alternative fonts
        // Option 1: Set a fonts folder globally (useful for PSD files)
        FontSettings.SetFontsFolder(AlternativeFontsFolder);
        FontSettings.UpdateFonts();

        // Option 2: Provide a custom font source (useful for vector formats)
        var loadOptions = new LoadOptions();
        loadOptions.AddCustomFontSource(GetFontSource, AlternativeFontsFolder);

        // Load the image with the configured options
        using (Image image = Image.Load(InputPath, loadOptions))
        {
            // For vector formats you might need rasterization options;
            // for raster formats like PSD the default options are sufficient.
            // Save the processed image
            image.Save(OutputPath, new PngOptions());
        }
    }

    // Custom font provider that reads all font files from the specified folder
    private static CustomFontData[] GetFontSource(params object[] args)
    {
        string fontsPath = string.Empty;
        if (args.Length > 0 && args[0] != null)
        {
            fontsPath = args[0].ToString();
        }

        var fontDataList = new System.Collections.Generic.List<CustomFontData>();
        if (Directory.Exists(fontsPath))
        {
            foreach (string fontFile in Directory.GetFiles(fontsPath))
            {
                // Use the file name without extension as the font family name
                string fontFamily = Path.GetFileNameWithoutExtension(fontFile);
                byte[] fontBytes = File.ReadAllBytes(fontFile);
                fontDataList.Add(new CustomFontData(fontFamily, fontBytes));
            }
        }

        return fontDataList.ToArray();
    }
}