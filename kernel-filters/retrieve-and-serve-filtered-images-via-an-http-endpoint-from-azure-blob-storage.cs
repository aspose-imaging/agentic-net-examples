using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input/output paths for safety checks
            string inputPath = "input.jpg";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputPath = "output\\output.jpg";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Hardcoded HTTP prefix
            string prefix = "http://localhost:5000/";

            // Initialize HttpListener
            using (var listener = new System.Net.HttpListener())
            {
                listener.Prefixes.Add(prefix);
                listener.Start();
                Console.WriteLine($"Listening on {prefix}");

                while (true)
                {
                    // Wait for an incoming request
                    var context = listener.GetContext();
                    var request = context.Request;
                    var response = context.Response;

                    // Expect a query parameter "url" containing the Azure Blob URL
                    string blobUrl = request.QueryString["url"];
                    if (string.IsNullOrEmpty(blobUrl))
                    {
                        response.StatusCode = 400; // Bad Request
                        using (var writer = new StreamWriter(response.OutputStream))
                        {
                            writer.Write("Missing 'url' query parameter.");
                        }
                        response.Close();
                        continue;
                    }

                    // Download the image from the blob URL
                    using (var httpClient = new System.Net.Http.HttpClient())
                    {
                        System.Net.Http.HttpResponseMessage httpResponse;
                        try
                        {
                            httpResponse = httpClient.GetAsync(blobUrl).Result;
                        }
                        catch
                        {
                            response.StatusCode = 500;
                            using (var writer = new StreamWriter(response.OutputStream))
                            {
                                writer.Write("Error retrieving the image from the provided URL.");
                            }
                            response.Close();
                            continue;
                        }

                        if (!httpResponse.IsSuccessStatusCode)
                        {
                            response.StatusCode = (int)httpResponse.StatusCode;
                            using (var writer = new StreamWriter(response.OutputStream))
                            {
                                writer.Write($"Failed to retrieve image. HTTP {(int)httpResponse.StatusCode}");
                            }
                            response.Close();
                            continue;
                        }

                        using (var inputStream = httpResponse.Content.ReadAsStreamAsync().Result)
                        {
                            // Load image using Aspose.Imaging
                            using (Image image = Image.Load(inputStream))
                            {
                                // Prepare JPEG options for output
                                var jpegOptions = new JpegOptions
                                {
                                    Quality = 90
                                };

                                // Save processed image to a memory stream
                                using (var outputStream = new MemoryStream())
                                {
                                    image.Save(outputStream, jpegOptions);
                                    byte[] imageBytes = outputStream.ToArray();

                                    // Return the image bytes in the HTTP response
                                    response.ContentType = "image/jpeg";
                                    response.ContentLength64 = imageBytes.Length;
                                    response.OutputStream.Write(imageBytes, 0, imageBytes.Length);
                                    response.OutputStream.Flush();
                                    response.Close();
                                }
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}