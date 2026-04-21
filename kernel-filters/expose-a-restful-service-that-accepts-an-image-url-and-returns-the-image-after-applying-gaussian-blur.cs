using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded listening prefix
            string prefix = "http://localhost:5000/";
            // Temporary file paths
            string inputPath = "temp_input.jpg";
            string outputPath = "temp_output.jpg";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up HTTP listener
            var listener = new System.Net.HttpListener();
            listener.Prefixes.Add(prefix);
            listener.Start();
            Console.WriteLine($"Listening on {prefix}");

            while (true)
            {
                var context = listener.GetContext();
                var request = context.Request;
                var response = context.Response;

                // Expect a query parameter named "url"
                string imageUrl = request.QueryString["url"];
                if (string.IsNullOrEmpty(imageUrl))
                {
                    response.StatusCode = 400;
                    using (var writer = new StreamWriter(response.OutputStream))
                    {
                        writer.Write("Missing 'url' query parameter.");
                    }
                    continue;
                }

                // Download the image to the input path
                using (var client = new System.Net.WebClient())
                {
                    client.DownloadFile(imageUrl, inputPath);
                }

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    response.StatusCode = 500;
                    using (var writer = new StreamWriter(response.OutputStream))
                    {
                        writer.Write("Failed to download image.");
                    }
                    continue;
                }

                // Apply Gaussian blur
                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)image;
                    raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));
                    raster.Save(outputPath);
                }

                // Return the processed image
                byte[] resultBytes = File.ReadAllBytes(outputPath);
                response.ContentType = "image/jpeg";
                response.ContentLength64 = resultBytes.Length;
                response.OutputStream.Write(resultBytes, 0, resultBytes.Length);
                response.OutputStream.Close();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}