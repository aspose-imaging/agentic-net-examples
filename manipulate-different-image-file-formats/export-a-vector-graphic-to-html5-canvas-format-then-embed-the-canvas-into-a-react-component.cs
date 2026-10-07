// HOW-TO: Export SVG to HTML5 Canvas and Embed in React Component using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Text;

namespace VectorExport
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "vector.svg";
                string outputPath = "CanvasComponent.jsx";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                string svgContent = File.ReadAllText(inputPath);
                string svgBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(svgContent));
                string dataUrl = $"data:image/svg+xml;base64,{svgBase64}";

                var sb = new StringBuilder();
                sb.AppendLine("import React, { useRef, useEffect } from 'react';");
                sb.AppendLine();
                sb.AppendLine("const CanvasComponent = () => {");
                sb.AppendLine("  const canvasRef = useRef(null);");
                sb.AppendLine();
                sb.AppendLine("  useEffect(() => {");
                sb.AppendLine("    const canvas = canvasRef.current;");
                sb.AppendLine("    if (!canvas) return;");
                sb.AppendLine("    const ctx = canvas.getContext('2d');");
                sb.AppendLine("    const img = new Image();");
                sb.AppendLine($"    img.src = \"{dataUrl}\";");
                sb.AppendLine("    img.onload = () => {");
                sb.AppendLine("      ctx.clearRect(0, 0, canvas.width, canvas.height);");
                sb.AppendLine("      ctx.drawImage(img, 0, 0, canvas.width, canvas.height);");
                sb.AppendLine("    };");
                sb.AppendLine("  }, []);");
                sb.AppendLine();
                sb.AppendLine("  return (");
                sb.AppendLine("    <canvas ref={canvasRef} width={500} height={500} />");
                sb.AppendLine("  );");
                sb.AppendLine("};");
                sb.AppendLine();
                sb.AppendLine("export default CanvasComponent;");

                File.WriteAllText(outputPath, sb.ToString());
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to display a server‑side SVG file inside a React web app without loading external assets, you can convert it to a Base64 data URL and draw it on an HTML5 canvas using C#.
 * 2. When building a dynamic dashboard that renders vector icons on a canvas for high‑resolution scaling, this code lets you generate a ready‑to‑use React component from an SVG at build time.
 * 3. When you want to embed vector graphics in a single‑page application while keeping the bundle size low, you can pre‑process the SVG in .NET and output a self‑contained React canvas component.
 * 4. When integrating legacy design assets stored as SVG into a modern React front‑end, this approach automates the conversion to a canvas element that works across browsers.
 * 5. When creating a reusable UI library that supplies vector illustrations as React components, you can use this C# script to produce JSX files that render the SVG on an HTML5 canvas.
 */
