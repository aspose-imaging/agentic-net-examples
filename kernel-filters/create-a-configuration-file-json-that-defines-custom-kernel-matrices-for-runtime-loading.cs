using System;
using System.IO;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define the output path for the JSON configuration file.
            string outputPath = "custom_kernels.json";

            // Ensure the output directory exists.
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Build the JSON content defining custom kernel matrices.
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.AppendLine("{");
            jsonBuilder.AppendLine("  \"kernels\": [");
            jsonBuilder.AppendLine("    {");
            jsonBuilder.AppendLine("      \"name\": \"CustomKernel1\",");
            jsonBuilder.AppendLine("      \"size\": 3,");
            jsonBuilder.AppendLine("      \"matrix\": [");
            jsonBuilder.AppendLine("        [0, -1, 0],");
            jsonBuilder.AppendLine("        [-1, 5, -1],");
            jsonBuilder.AppendLine("        [0, -1, 0]");
            jsonBuilder.AppendLine("      ]");
            jsonBuilder.AppendLine("    },");
            jsonBuilder.AppendLine("    {");
            jsonBuilder.AppendLine("      \"name\": \"CustomKernel2\",");
            jsonBuilder.AppendLine("      \"size\": 5,");
            jsonBuilder.AppendLine("      \"matrix\": [");
            jsonBuilder.AppendLine("        [1, 1, 1, 1, 1],");
            jsonBuilder.AppendLine("        [1, 2, 2, 2, 1],");
            jsonBuilder.AppendLine("        [1, 2, 3, 2, 1],");
            jsonBuilder.AppendLine("        [1, 2, 2, 2, 1],");
            jsonBuilder.AppendLine("        [1, 1, 1, 1, 1]");
            jsonBuilder.AppendLine("      ]");
            jsonBuilder.AppendLine("    }");
            jsonBuilder.AppendLine("  ]");
            jsonBuilder.AppendLine("}");

            // Write the JSON content to the file.
            File.WriteAllText(outputPath, jsonBuilder.ToString());

            Console.WriteLine($"Configuration file created at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer wants to let end‑users choose or edit sharpening, edge‑enhancement or blur filters without recompiling, they can generate a JSON file with custom kernel matrices and load it at runtime with Aspose.Imaging.
 * 2. When an application processes medical or satellite images and requires a specific 5×5 convolution mask for noise reduction, the code can create a configuration file that stores the matrix for later use by the imaging pipeline.
 * 3. When a CI/CD pipeline needs to test multiple custom filters across different image formats such as JPEG, PNG or TIFF, the JSON file provides a portable definition of each kernel that can be swapped automatically during test runs.
 * 4. When a developer builds a plug‑in architecture where third‑party developers supply their own convolution kernels, this code generates the JSON schema that the plug‑in can read to apply the custom filter at runtime.
 * 5. When an image‑processing service must support locale‑specific visual effects (e.g., a stylized emboss for a marketing campaign), the JSON configuration lets the service load the appropriate kernel matrix without hard‑coding values in C#.
 */