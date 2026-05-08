using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define URLs and temporary file paths
            string downloadUrl = "https://example.com/input.svg";
            string uploadUrl = "https://example.com/upload";
            string tempSvgPath = Path.Combine(Path.GetTempPath(), "downloaded.svg");
            string outputPath = Path.Combine(Path.GetTempPath(), "blurred.png");

            // Download SVG from REST API
            using (System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient())
            {
                using (System.IO.Stream downloadStream = httpClient.GetStreamAsync(downloadUrl).Result)
                using (FileStream fileStream = new FileStream(tempSvgPath, FileMode.Create, FileAccess.Write))
                {
                    downloadStream.CopyTo(fileStream);
                }
            }

            // Verify the SVG file was saved
            if (!File.Exists(tempSvgPath))
            {
                Console.Error.WriteLine($"File not found: {tempSvgPath}");
                return;
            }

            // Load SVG image from the temporary file
            using (FileStream svgFileStream = new FileStream(tempSvgPath, FileMode.Open, FileAccess.Read))
            using (SvgImage svgImage = new SvgImage(svgFileStream))
            {
                // Prepare rasterization options for PNG output
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions();
                rasterOptions.PageSize = svgImage.Size;

                PngOptions pngOptions = new PngOptions();
                pngOptions.VectorRasterizationOptions = rasterOptions;

                // Rasterize SVG to a memory stream
                using (MemoryStream rasterStream = new MemoryStream())
                {
                    svgImage.Save(rasterStream, pngOptions);
                    rasterStream.Position = 0;

                    // Load rasterized image as RasterImage
                    using (RasterImage rasterImage = (RasterImage)Image.Load(rasterStream))
                    {
                        // Apply Gaussian blur filter (radius 5, sigma 4.0)
                        rasterImage.Filter(rasterImage.Bounds,
                            new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                        // Ensure output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the blurred image to PNG file
                        rasterImage.Save(outputPath);
                    }
                }
            }

            // Verify the output file was created
            if (!File.Exists(outputPath))
            {
                Console.Error.WriteLine($"File not found: {outputPath}");
                return;
            }

            // Upload the blurred PNG back to the REST API
            using (System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient())
            using (FileStream uploadStream = new FileStream(outputPath, FileMode.Open, FileAccess.Read))
            {
                System.Net.Http.StreamContent content = new System.Net.Http.StreamContent(uploadStream);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/png");
                System.Net.Http.HttpResponseMessage response = httpClient.PostAsync(uploadUrl, content).Result;
                // Optionally handle response
                if (!response.IsSuccessStatusCode)
                {
                    Console.Error.WriteLine($"Upload failed: {response.StatusCode}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}