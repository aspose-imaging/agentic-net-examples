using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main(string[] args)
    {
        // Set up input and output directories
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

        // Ensure input directory exists
        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
            return;
        }

        // Ensure output directory exists
        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        // Get all EMF files in the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.emf");

        foreach (var inputPath in files)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Prepare output path with .svg extension
            string fileName = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputDirectory, fileName + ".svg");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EMF image and convert to SVG
            using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
            {
                // Set up SVG save options
                SvgOptions saveOptions = new SvgOptions
                {
                    TextAsShapes = true
                };

                // Configure rasterization options for EMF
                EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
                {
                    BackgroundColor = Color.WhiteSmoke,
                    PageSize = emfImage.Size,
                    RenderMode = EmfRenderMode.Auto,
                    BorderX = 0,
                    BorderY = 0
                };

                saveOptions.VectorRasterizationOptions = rasterOptions;

                // Save as SVG
                emfImage.Save(outputPath, saveOptions);
            }
        }
    }
}