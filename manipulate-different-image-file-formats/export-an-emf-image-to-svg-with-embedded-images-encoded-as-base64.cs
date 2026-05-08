using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Svg;

namespace EmfToSvgExport
{
    // Callback that embeds raster resources as Base64 data URIs
    class Base64SvgResourceKeeperCallback : SvgResourceKeeperCallback
    {
        public override string OnImageResourceReady(byte[] imageData, SvgImageType imageType, string suggestedFileName, ref bool useEmbeddedImage)
        {
            // Force embedding of the image
            useEmbeddedImage = true;

            // Convert image bytes to Base64 string
            string base64 = Convert.ToBase64String(imageData);

            // Determine MIME type based on the image type
            string mime = imageType switch
            {
                SvgImageType.Jpeg => "image/jpeg",
                SvgImageType.Png => "image/png",
                SvgImageType.Gif => "image/gif",
                SvgImageType.Bmp => "image/bmp",
                SvgImageType.Tiff => "image/tiff",
                _ => "application/octet-stream"
            };

            // Return a data URI that will be written directly into the SVG
            return $"data:{mime};base64,{base64}";
        }
    }

    class Program
    {
        static void Main()
        {
            // Hard‑coded input and output paths
            string inputPath = @"C:\Images\test.emf";
            string outputPath = @"C:\Images\test.svg";

            try
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the EMF image
                using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
                {
                    // Prepare SVG save options
                    var svgOptions = new SvgOptions
                    {
                        TextAsShapes = true,
                        Callback = new Base64SvgResourceKeeperCallback()
                    };

                    // Configure rasterization options for EMF
                    var rasterOptions = new EmfRasterizationOptions
                    {
                        PageSize = emfImage.Size,
                        BackgroundColor = Color.WhiteSmoke,
                        RenderMode = EmfRenderMode.Auto,
                        BorderX = 0,
                        BorderY = 0
                    };

                    svgOptions.VectorRasterizationOptions = rasterOptions;

                    // Save as SVG with embedded images encoded as Base64
                    emfImage.Save(outputPath, svgOptions);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}