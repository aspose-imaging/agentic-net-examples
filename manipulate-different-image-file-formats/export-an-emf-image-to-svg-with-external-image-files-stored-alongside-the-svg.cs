using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class ExternalResourceKeeper : SvgResourceKeeperCallback
{
    private readonly string _outputDirectory;

    public ExternalResourceKeeper(string outputDirectory)
    {
        _outputDirectory = outputDirectory;
    }

    public override string OnImageResourceReady(byte[] imageData, SvgImageType imageType, string suggestedFileName, ref bool useEmbeddedImage)
    {
        // Save the external image next to the SVG file.
        // The caller expects a relative path, so we return only the file name.
        string fileName = suggestedFileName;
        if (string.IsNullOrEmpty(fileName))
        {
            // Fallback name if none is suggested.
            fileName = $"resource_{Guid.NewGuid()}.png";
        }

        string fullPath = Path.Combine(_outputDirectory, fileName);
        File.WriteAllBytes(fullPath, imageData);

        // Indicate that the image should not be embedded.
        useEmbeddedImage = false;

        // Return the relative path (just the file name).
        return fileName;
    }
}

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths.
        string inputPath = @"C:\temp\test.emf";
        string outputPath = @"C:\temp\test.output.svg";

        // Verify input file existence.
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists.
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EMF image.
        using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
        {
            // Prepare SVG save options.
            SvgOptions svgOptions = new SvgOptions
            {
                TextAsShapes = true,
                // Use a custom callback to store external resources beside the SVG.
                Callback = new ExternalResourceKeeper(Path.GetDirectoryName(outputPath))
            };

            // Configure rasterization options for EMF.
            EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
            {
                BackgroundColor = Color.WhiteSmoke,
                PageSize = emfImage.Size,
                RenderMode = EmfRenderMode.Auto,
                BorderX = 50,
                BorderY = 50
            };

            svgOptions.VectorRasterizationOptions = rasterOptions;

            // Save the SVG file.
            emfImage.Save(outputPath, svgOptions);
        }
    }
}