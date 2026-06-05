using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input, output and fonts directories
            string inputPath = Path.Combine("Input", "sample.odg");
            string outputPath = Path.Combine("Output", "sample.pdf");
            string fontsPath = Path.Combine("Fonts");

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load options with custom font source
            var loadOptions = new Aspose.Imaging.ImageLoadOptions.OdLoadOptions();
            loadOptions.AddCustomFontSource(args =>
            {
                string path = args.Length > 0 ? args[0]?.ToString() : string.Empty;
                var fontList = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
                if (!string.IsNullOrEmpty(path) && Directory.Exists(path))
                {
                    foreach (var file in Directory.GetFiles(path))
                    {
                        string name = Path.GetFileNameWithoutExtension(file);
                        byte[] data = File.ReadAllBytes(file);
                        fontList.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(name, data));
                    }
                }
                return fontList.ToArray();
            }, fontsPath);

            // Load the ODG image with the custom fonts
            using (Image image = Image.Load(inputPath, loadOptions))
            {
                // Configure rasterization options for ODG
                var rasterOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = image.Size
                };

                // Set PDF save options
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    pdfOptions.VectorRasterizationOptions = rasterOptions;
                    image.Save(outputPath, pdfOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}