// HOW-TO: Batch Replace Placeholder with HTML5 Canvas in Multiple HTML Files Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;

namespace BatchCanvasEmbedder
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded paths
                string inputDirectory = "input";
                string outputDirectory = "output";
                string placeholderToken = "{{CANVAS}}";

                // Ensure output base directory exists
                Directory.CreateDirectory(outputDirectory);

                // Get all .html files in the input directory
                string[] inputFiles = Directory.GetFiles(inputDirectory, "*.html");

                foreach (string inputFilePath in inputFiles)
                {
                    // Validate input file existence
                    if (!File.Exists(inputFilePath))
                    {
                        Console.Error.WriteLine($"File not found: {inputFilePath}");
                        return;
                    }

                    // Read input file content
                    string content = File.ReadAllText(inputFilePath);

                    // Generate canvas HTML snippet
                    string canvasHtml = GenerateCanvasHtml();

                    // Replace placeholder token with canvas HTML
                    string outputContent = content.Replace(placeholderToken, canvasHtml);

                    // Determine output file path
                    string fileName = Path.GetFileName(inputFilePath);
                    string outputFilePath = Path.Combine(outputDirectory, fileName);

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputFilePath));

                    // Write the modified content to the output file
                    File.WriteAllText(outputFilePath, outputContent);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }

        static string GenerateCanvasHtml()
        {
            return @"
<canvas id=""myCanvas"" width=""500"" height=""400""></canvas>
<script>
    var canvas = document.getElementById('myCanvas');
    var ctx = canvas.getContext('2d');
    // Example drawing
    ctx.fillStyle = '#FF0000';
    ctx.fillRect(0, 0, 150, 75);
</script>
";
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to insert a dynamically generated HTML5 canvas into dozens of existing web pages that contain a {{CANVAS}} token.
 * 2. When you want to automate the creation of interactive charts across a set of static HTML reports by replacing a placeholder with canvas markup.
 * 3. When a marketing team provides template HTML files and you must programmatically embed a drawing surface without manually editing each file.
 * 4. When you are building a documentation generator that adds a canvas element to every page to display image annotations.
 * 5. When you need to update legacy HTML tutorials in bulk by inserting a canvas element for new interactive examples.
 */
