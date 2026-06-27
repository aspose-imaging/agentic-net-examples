using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define the output path for the JSON configuration file.
            string outputPath = "config/kernels.json";

            // Ensure the output directory exists.
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // JSON content defining custom kernel matrices.
            string jsonContent = @"{
  ""kernels"": [
    {
      ""name"": ""CustomEmboss"",
      ""size"": 3,
      ""matrix"": [
        [ -2, -1, 0 ],
        [ -1, 1, 1 ],
        [ 0, 1, 2 ]
      ]
    },
    {
      ""name"": ""CustomBlur"",
      ""size"": 3,
      ""matrix"": [
        [ 1, 1, 1 ],
        [ 1, 1, 1 ],
        [ 1, 1, 1 ]
      ]
    }
  ]
}";

            // Write the JSON content to the file.
            File.WriteAllText(outputPath, jsonContent);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer wants to apply a custom emboss effect to JPEG or PNG images at runtime without recompiling the application, they can generate a JSON file with the kernel matrix using this code.
 * 2. When an image processing pipeline needs to switch between different blur strengths for TIFF files based on user preferences, the JSON configuration created here allows dynamic loading of the custom blur kernel.
 * 3. When a SaaS platform must let administrators define new convolution filters for uploaded PDFs converted to images, this code provides a way to store those filter definitions in a discoverable JSON file.
 * 4. When a desktop application requires localized image effects that can be updated via configuration files rather than code changes, the generated kernels.json enables runtime selection of the appropriate matrix.
 * 5. When a CI/CD build process needs to bundle custom convolution kernels for automated testing of Aspose.Imaging filters across BMP and GIF formats, this snippet creates the required JSON configuration automatically.
 */