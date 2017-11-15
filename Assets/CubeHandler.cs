using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using LightJson;
using UnityEngine;
using UnityEngine.UI;

public class CubeHandler : MonoBehaviour
{
    public static int selectedCube = 0;
    public static List<Cube> cubes = new List<Cube>();
    private static List<GameObject> renderCubes = new List<GameObject>();
    public Exporter saver = new EchneExporter();
    public Importer loader = new EchneImporter();
    public Project project = new Project();

    private void Awake()
    {
        project.name = "Test";
    }

    private void Start()
    {
        CreateACube();
    }

    public static int CreateACube()
    {
        Cube cube = new Cube();
        cube.name = "Cube";
        cube.dimensionX = 1;
        cube.dimensionY = 1;
        cube.dimensionZ = 1;
        cube.posX = 0;
        cube.posY = 0;
        cube.posZ = 0;
        cube.rotationX = 0;
        cube.rotationY = 0;
        cube.rotationZ = 0;
        cube.rotatePointX = 0.5f;
        cube.rotatePointY = 0.5f;
        cube.rotatePointZ = 0.5f;
        cubes.Add(cube);
        GameObject rotation = new GameObject();
        rotation.transform.localPosition = new Vector3((cube.posX - 8 + cube.dimensionX / 2) / 8, (cube.posY + cube.dimensionY / 2) / 8, (cube.posZ - 8 + cube.dimensionZ / 2) / 8);
        rotation.name = "Cube" + renderCubes.Count;
        GameObject renderCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        renderCube.transform.parent = rotation.transform;
        renderCube.AddComponent<RenderCube>();
        renderCube.GetComponent<RenderCube>().id = renderCubes.Count;
        rotation.AddComponent<RotatePoint>();
        renderCubes.Add(renderCube);
        updateCube(renderCubes.Count - 1);
        return renderCubes.Count - 1;
    }

    public static void SelectCube(int id)
    {
        renderCubes[selectedCube].GetComponent<RenderCube>().selected = false;
        CubesList.texts[selectedCube].GetComponentInChildren<Text>().color = Color.white;
        selectedCube = id;
        renderCubes[id].GetComponent<RenderCube>().selected = true;
        CubesList.texts[id].GetComponentInChildren<Text>().color = Color.blue;
        FormHandler.notSelecting = false;
        GameObject.FindGameObjectWithTag("xPos").GetComponent<InputField>().text = cubes[id].posX + "";
        GameObject.FindGameObjectWithTag("yPos").GetComponent<InputField>().text = cubes[id].posY + "";
        GameObject.FindGameObjectWithTag("zPos").GetComponent<InputField>().text = cubes[id].posZ + "";
        GameObject.FindGameObjectWithTag("xDimension").GetComponent<InputField>().text = cubes[id].dimensionX + "";
        GameObject.FindGameObjectWithTag("yDimension").GetComponent<InputField>().text = cubes[id].dimensionY + "";
        GameObject.FindGameObjectWithTag("zDimension").GetComponent<InputField>().text = cubes[id].dimensionZ + "";
        GameObject.FindGameObjectWithTag("xRotation").GetComponent<InputField>().text = cubes[id].rotationX + "";
        GameObject.FindGameObjectWithTag("yRotation").GetComponent<InputField>().text = cubes[id].rotationY + "";
        GameObject.FindGameObjectWithTag("zRotation").GetComponent<InputField>().text = cubes[id].rotationZ + "";
        GameObject.FindGameObjectWithTag("xRotationSlider").GetComponent<Slider>().value = (cubes[id].rotationX + 180) / 360;
        GameObject.FindGameObjectWithTag("yRotationSlider").GetComponent<Slider>().value = (cubes[id].rotationY + 180) / 360;
        GameObject.FindGameObjectWithTag("zRotationSlider").GetComponent<Slider>().value = (cubes[id].rotationZ + 180) / 360;
        GameObject.FindGameObjectWithTag("xRotationPoint").GetComponent<InputField>().text = cubes[id].rotatePointX + "";
        GameObject.FindGameObjectWithTag("yRotationPoint").GetComponent<InputField>().text = cubes[id].rotatePointY + "";
        GameObject.FindGameObjectWithTag("zRotationPoint").GetComponent<InputField>().text = cubes[id].rotatePointZ + "";
        GameObject.FindGameObjectWithTag("name").GetComponent<InputField>().text = cubes[id].name;
        FormHandler.notSelecting = true;
    }

    public static void updateCube(int cubeId)
    {
        Cube cube = cubes[cubeId];
        if (renderCubes.Count != cubes.Count)
        {
            if (renderCubes.Count <= cubes.Count)
            {
                for (int i = 0; i < cubes.Count - renderCubes.Count; i++)
                {
                    GameObject rotation = new GameObject();
                    rotation.transform.localPosition = new Vector3((cube.posX - 8 + cube.dimensionX / 2) / 8,
                        (cube.posY + cube.dimensionY / 2) / 8, (cube.posZ - 8 + cube.dimensionZ / 2) / 8);
                    rotation.name = "Cube" + renderCubes.Count;
                    GameObject cubie = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cubie.transform.parent = rotation.transform;
                    cubie.AddComponent<RenderCube>();
                    cubie.GetComponent<RenderCube>().id = renderCubes.Count;
                    rotation.AddComponent<RotatePoint>();
                    renderCubes.Add(cubie);
                }
            }
            else
            {
                renderCubes.RemoveRange(cubes.Count, cubes.Count - renderCubes.Count);
            }
        }
        GameObject renderCube = renderCubes[cubeId];
        renderCube.transform.parent.transform.localPosition = new Vector3(cube.rotatePointX / 8 - 1, cube.rotatePointY / 8, cube.rotatePointZ / 8 - 1);
        renderCube.transform.parent.transform.localEulerAngles = new Vector3(cube.rotationX, cube.rotationY, cube.rotationZ);
        renderCube.transform.localPosition = new Vector3((cube.posX - 8 + cube.dimensionX / 2) / 8, (cube.posY + cube.dimensionY / 2) / 8, (cube.posZ - 8 + cube.dimensionZ / 2) / 8) - renderCube.transform.parent.transform.localPosition;
        renderCube.transform.localScale = new Vector3(cube.dimensionX / 8, cube.dimensionY / 8, cube.dimensionZ / 8);
    }

    public void Save()
    {
        saver.WriteToFile("saves/" + project.name + saver.getExportExtension());
    }
    
    public void Load()
    {
        loader.ReadFromFile("saves/" + project.name + saver.getExportExtension());
        for (int i = 0; i < cubes.Count; i++)
        {
            updateCube(i);
            SelectCube(i);
        }
    }
}

public class Project
{
    public string name;
}

public class RenderCube : MonoBehaviour
{
    public int id;
    public bool selected;
    
    private static Material lineMaterial;

    private void Awake()
    {
        lineMaterial = new Material(Shader.Find("Diffuse"));
        lineMaterial.color = Color.blue;
    }
    
    private Vector3[] GetVertexPositions() {
        var vertices = new Vector3[8];
        var thisMatrix = this.transform.localToWorldMatrix;
        var storedRotation = this.transform.rotation;
        this.transform.rotation = Quaternion.identity;
   
        var extents = this.GetComponent<MeshFilter>().mesh.bounds.extents;
        vertices[0] = thisMatrix.MultiplyPoint3x4(extents);
        vertices[1] = thisMatrix.MultiplyPoint3x4(new Vector3(-extents.x, extents.y, extents.z));
        vertices[2] = thisMatrix.MultiplyPoint3x4(new Vector3(extents.x, extents.y, -extents.z));
        vertices[3] = thisMatrix.MultiplyPoint3x4(new Vector3(-extents.x, extents.y, -extents.z));
        vertices[4] = thisMatrix.MultiplyPoint3x4(new Vector3(extents.x, -extents.y, extents.z));
        vertices[5] = thisMatrix.MultiplyPoint3x4(new Vector3(-extents.x, -extents.y, extents.z));
        vertices[6] = thisMatrix.MultiplyPoint3x4(new Vector3(extents.x, -extents.y, -extents.z));
        vertices[7] = thisMatrix.MultiplyPoint3x4(-extents);
   
        this.transform.rotation = storedRotation;
        return vertices;
    }

    private float thickness = 0.01f;
    
    private void OnRenderObject()
    {
        if (selected)
        {
            //GL.wireframe = true;
            lineMaterial.SetPass(0);
            /*
            GL.PushMatrix();
            GL.Begin(GL.QUADS);
            GL.Color(Color.blue);
            float xPos = CubeHandler.cubes[id].rotatePointX / 8 - 1;
            float yPos = CubeHandler.cubes[id].rotatePointY / 8;
            float zPos = CubeHandler.cubes[id].rotatePointZ / 8 - 1;
            
            GL.Vertex3(xPos + thickness, yPos + thickness, zPos - thickness);
            GL.Vertex3(xPos - thickness, yPos + thickness, zPos - thickness);
            GL.Vertex3(xPos - thickness, yPos + thickness, zPos + thickness);
            GL.Vertex3(xPos + thickness, yPos + thickness, zPos + thickness);
            
            GL.Vertex3(xPos + thickness, yPos - thickness, zPos + thickness);
            GL.Vertex3(xPos - thickness, yPos - thickness, zPos + thickness);
            GL.Vertex3(xPos - thickness, yPos - thickness, zPos - thickness);
            GL.Vertex3(xPos + thickness, yPos - thickness, zPos - thickness);
            
            GL.Vertex3(xPos + thickness, yPos - thickness, zPos + thickness);
            GL.Vertex3(xPos + thickness, yPos - thickness, zPos - thickness);
            GL.Vertex3(xPos + thickness, yPos + thickness, zPos - thickness);
            GL.Vertex3(xPos + thickness, yPos + thickness, zPos + thickness);
            
            GL.Vertex3(xPos - thickness, yPos - thickness, zPos - thickness);
            GL.Vertex3(xPos - thickness, yPos - thickness, zPos + thickness);
            GL.Vertex3(xPos - thickness, yPos + thickness, zPos + thickness);
            GL.Vertex3(xPos - thickness, yPos + thickness, zPos - thickness);
            
            GL.Vertex3(xPos + thickness, yPos - thickness, zPos - thickness);
            GL.Vertex3(xPos - thickness, yPos - thickness, zPos - thickness);
            GL.Vertex3(xPos - thickness, yPos + thickness, zPos - thickness);
            GL.Vertex3(xPos + thickness, yPos + thickness, zPos - thickness);
            
            GL.Vertex3(xPos - thickness, yPos - thickness, zPos + thickness);
            GL.Vertex3(xPos + thickness, yPos - thickness, zPos + thickness);
            GL.Vertex3(xPos + thickness, yPos + thickness, zPos + thickness);
            GL.Vertex3(xPos - thickness, yPos + thickness, zPos + thickness);
            
            GL.End();
            GL.PopMatrix();
            */
            GL.PushMatrix();
            GL.Begin(GL.LINES);
            GL.Color(Color.blue);
            Vector3[] vertices = GetVertexPositions();
            drawThickLine(vertices[0], vertices[1]);
            drawThickLine(vertices[0], vertices[2]);
            drawThickLine(vertices[0], vertices[4]);
            drawThickLine(vertices[1], vertices[5]);
            drawThickLine(vertices[1], vertices[3]);
            drawThickLine(vertices[2], vertices[6]);
            drawThickLine(vertices[2], vertices[3]);
            drawThickLine(vertices[3], vertices[7]);
            drawThickLine(vertices[4], vertices[5]);
            drawThickLine(vertices[4], vertices[6]);
            drawThickLine(vertices[5], vertices[7]);
            drawThickLine(vertices[6], vertices[7]);
            GL.End();
            GL.PopMatrix();
        }
    }

    private void drawThickLine(Vector3 start, Vector3 end)
    {
        GL.Vertex(start);
        GL.Vertex(end);
    }
}

public class RotatePoint : MonoBehaviour
{
    private RenderCube renderCube;

    private void Start()
    {
        renderCube = GetComponentInChildren<RenderCube>();
    }

    private float thickness = 0.01f;

    private void OnRenderObject()
    {
        if (renderCube.selected)
        {
            GL.PushMatrix();
            GL.Begin(GL.QUADS);
            GL.Color(Color.blue);

            GL.Vertex3(transform.localPosition.x + thickness, transform.localPosition.y + thickness,
                transform.localPosition.z - thickness);
            GL.Vertex3(transform.localPosition.x - thickness, transform.localPosition.y + thickness,
                transform.localPosition.z - thickness);
            GL.Vertex3(transform.localPosition.x - thickness, transform.localPosition.y + thickness,
                transform.localPosition.z + thickness);
            GL.Vertex3(transform.localPosition.x + thickness, transform.localPosition.y + thickness,
                transform.localPosition.z + thickness);

            GL.Vertex3(transform.localPosition.x + thickness, transform.localPosition.y - thickness,
                transform.localPosition.z + thickness);
            GL.Vertex3(transform.localPosition.x - thickness, transform.localPosition.y - thickness,
                transform.localPosition.z + thickness);
            GL.Vertex3(transform.localPosition.x - thickness, transform.localPosition.y - thickness,
                transform.localPosition.z - thickness);
            GL.Vertex3(transform.localPosition.x + thickness, transform.localPosition.y - thickness,
                transform.localPosition.z - thickness);

            GL.Vertex3(transform.localPosition.x + thickness, transform.localPosition.y - thickness,
                transform.localPosition.z + thickness);
            GL.Vertex3(transform.localPosition.x + thickness, transform.localPosition.y - thickness,
                transform.localPosition.z - thickness);
            GL.Vertex3(transform.localPosition.x + thickness, transform.localPosition.y + thickness,
                transform.localPosition.z - thickness);
            GL.Vertex3(transform.localPosition.x + thickness, transform.localPosition.y + thickness,
                transform.localPosition.z + thickness);

            GL.Vertex3(transform.localPosition.x - thickness, transform.localPosition.y - thickness,
                transform.localPosition.z - thickness);
            GL.Vertex3(transform.localPosition.x - thickness, transform.localPosition.y - thickness,
                transform.localPosition.z + thickness);
            GL.Vertex3(transform.localPosition.x - thickness, transform.localPosition.y + thickness,
                transform.localPosition.z + thickness);
            GL.Vertex3(transform.localPosition.x - thickness, transform.localPosition.y + thickness,
                transform.localPosition.z - thickness);

            GL.Vertex3(transform.localPosition.x + thickness, transform.localPosition.y - thickness,
                transform.localPosition.z - thickness);
            GL.Vertex3(transform.localPosition.x - thickness, transform.localPosition.y - thickness,
                transform.localPosition.z - thickness);
            GL.Vertex3(transform.localPosition.x - thickness, transform.localPosition.y + thickness,
                transform.localPosition.z - thickness);
            GL.Vertex3(transform.localPosition.x + thickness, transform.localPosition.y + thickness,
                transform.localPosition.z - thickness);

            GL.Vertex3(transform.localPosition.x - thickness, transform.localPosition.y - thickness,
                transform.localPosition.z + thickness);
            GL.Vertex3(transform.localPosition.x + thickness, transform.localPosition.y - thickness,
                transform.localPosition.z + thickness);
            GL.Vertex3(transform.localPosition.x + thickness, transform.localPosition.y + thickness,
                transform.localPosition.z + thickness);
            GL.Vertex3(transform.localPosition.x - thickness, transform.localPosition.y + thickness,
                transform.localPosition.z + thickness);

            GL.End();
            GL.PopMatrix();
        }
    }
}

public class Cube
{
    public string name;
    public float posX, posY, posZ;
    public float dimensionX, dimensionY, dimensionZ;
    public float rotationX, rotationY, rotationZ;
    public float rotatePointX, rotatePointY, rotatePointZ;
}

public interface Exporter
{
    string getExportExtension();
    void WriteToFile(String filePath);
}

public interface Importer
{
    void ReadFromFile(String filePath);
}

public class EchneExporter : Exporter
{
    public string getExportExtension()
    {
        return ".ecn";
    }

    public void WriteToFile(string filePath)
    {
        var json = new JsonObject();
        var array = new JsonArray();
        foreach (Cube cube in CubeHandler.cubes)
        {
            JsonObject jsonCube = new JsonObject();
            jsonCube.Add("name", cube.name);
            jsonCube.Add("xPos", cube.posX);
            jsonCube.Add("yPos", cube.posY);
            jsonCube.Add("zPos", cube.posZ);
            jsonCube.Add("xDimension", cube.dimensionX);
            jsonCube.Add("yDimension", cube.dimensionY);
            jsonCube.Add("zDimension", cube.dimensionZ);
            jsonCube.Add("xRotation", cube.rotationX);
            jsonCube.Add("yRotation", cube.rotationY);
            jsonCube.Add("zRotation", cube.rotationZ);
            jsonCube.Add("xRotationPoint", cube.rotatePointX);
            jsonCube.Add("yRotationPoint", cube.rotatePointY);
            jsonCube.Add("zRotationPoint", cube.rotatePointZ);
            array.Add(jsonCube);
        }
        json.Add("cubes", array);
        GZipStream stream = new GZipStream(new FileStream(filePath, FileMode.OpenOrCreate), CompressionMode.Compress);
        byte[] buffer = Encoding.UTF8.GetBytes(json.ToString());
        byte[] length = BitConverter.GetBytes((long) buffer.Length);
        stream.Write(length, 0, 8);
        stream.Write(buffer, 0, buffer.Length);
        stream.Close();
    }
}

public class EchneImporter : Importer
{
    public void ReadFromFile(string filePath)
    {
        GZipStream stream = new GZipStream(new FileStream(filePath, FileMode.Open), CompressionMode.Decompress);

        byte[] lengthBuffer = new byte[8];
        stream.Read(lengthBuffer, 0, 8);
        long length = BitConverter.ToInt64(lengthBuffer, 0);
        byte[] buffer = new byte[length];
        for (int i = 0; i < length; i++)
        {
            buffer[i] = (byte) stream.ReadByte();
        }
        stream.Close();
        string output = Encoding.UTF8.GetString(buffer);
        Console.WriteLine(output);
        JsonObject json = JsonValue.Parse(output);
        var cubes = json["cubes"].AsJsonArray;
        List<Cube> result = new List<Cube>();
        foreach (JsonObject jsonCube in cubes)
        {
            Cube cube = new Cube();
            cube.name = jsonCube["name"].AsString;
            cube.posX = (float) jsonCube["xPos"].AsNumber;
            cube.posY = (float) jsonCube["yPos"].AsNumber;
            cube.posZ = (float) jsonCube["zPos"].AsNumber;
            cube.dimensionX = (float) jsonCube["xDimension"].AsNumber;
            cube.dimensionY = (float) jsonCube["yDimension"].AsNumber;
            cube.dimensionZ = (float) jsonCube["zDimension"].AsNumber;
            cube.rotationX = (float) jsonCube["xRotation"].AsNumber;
            cube.rotationY = (float) jsonCube["yRotation"].AsNumber;
            cube.rotationZ = (float) jsonCube["zRotation"].AsNumber;
            cube.rotatePointX = (float) jsonCube["xRotationPoint"].AsNumber;
            cube.rotatePointY = (float) jsonCube["yRotationPoint"].AsNumber;
            cube.rotatePointZ = (float) jsonCube["zRotationPoint"].AsNumber;
            result.Add(cube);
        }
        CubeHandler.cubes = result;
    }
}
