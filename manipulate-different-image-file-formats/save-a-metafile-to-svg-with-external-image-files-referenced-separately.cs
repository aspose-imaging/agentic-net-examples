using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

namespace MetafileToSvgExample
{
    // Callback that saves image resources as external files and returns their relative paths.
    class ExternalResourceKeeper : SvgResourceKeeperCallback
    {
        private readonly string _baseFolder;

        public ExternalResourceKeeper(string baseFolder)
        {
            _baseFolder = baseFolder;
        }

        // Called for each raster image resource inside the metafile.
        public override string OnImageResourceReady(byte[] imageData, SvgImageType imageType,
                                                    string suggestedFileName, ref bool useEmbeddedImage)
        {
            // Force external storage.
            useEmbeddedImage = false;

            // Ensure the target directory exists.
            string targetPath = Path.Combine(_baseFolder, suggestedFileName);
            Directory.CreateDirectory(Path.GetDirectoryName(targetPath));

            // Write the image data to a file.
            File.WriteAllBytes(targetPath, imageData);

            // Return the relative path that will be placed into the SVG.
            return suggestedFileName;
        }

        // Called when the SVG document itself is ready.
        public override string OnSvgDocumentReady(byte[] htmlData, string suggestedFileName)
        {
            // Save the SVG document (optional – Aspose.Imaging also writes it).
            string targetPath = Path.Combine(_baseFolder, suggestedFileName);
            Directory.CreateDirectory(Path.GetDirectoryName(targetPath));
            File.WriteAllBytes(targetPath, htmlData);

            // Return the relative path (file name) for consistency.
            return suggestedFileName;
        }
    }

    class Program
    {
        static void Main()
        {
            // Hard‑coded input and output paths.
            string inputPath = @"C:\Images\sample.emf";
            string outputPath = @"C:\Images\output.svg";

            // Validate input file existence.
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists.
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            try
            {
                // Load the metafile.
                using (Image image = Image.Load(inputPath))
                {
                    // Prepare SVG export options with the external resource callback.
                    var svgOptions = new SvgOptions
                    {
                        Callback = new ExternalResourceKeeper(Path.GetDirectoryName(outputPath))
                    };

                    // Save the image as SVG; external raster resources will be stored separately.
                    image.Save(outputPath, svgOptions);
                }
            }
            catch (Exception ex)
            {
                // Report any runtime errors without crashing.
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}