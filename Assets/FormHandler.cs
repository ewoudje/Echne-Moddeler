using UnityEngine;
using UnityEngine.UI;

public class FormHandler : MonoBehaviour
{
	private int cubie = -1;
	public static bool notSelecting = true;

	private void Update()
	{
		if (cubie != -1)
		{
			CubeHandler.SelectCube(cubie);
			cubie = -1;
		}
	}

	public void onNameChange(string name)
	{
		if (notSelecting)
		{
			CubeHandler.cubes[CubeHandler.selectedCube].name = name;
			CubeHandler.updateCube(CubeHandler.selectedCube);
		}
	}

	public void onPosXChange(string pos)
	{
		if (notSelecting)
		{
			float old = CubeHandler.cubes[CubeHandler.selectedCube].posX;
			float.TryParse(pos, out CubeHandler.cubes[CubeHandler.selectedCube].posX);
			CubeHandler.cubes[CubeHandler.selectedCube].rotatePointX += CubeHandler.cubes[CubeHandler.selectedCube].posX - old;
			CubeHandler.updateCube(CubeHandler.selectedCube);
		}
	}

	public void onPosXUp()
	{
		float d;
		float.TryParse(GameObject.FindGameObjectWithTag("xPos").GetComponent<InputField>().text, out d);
		float old = d;
		if (d % 1f == 0) d++;
		else d += 0.1f;
		CubeHandler.cubes[CubeHandler.selectedCube].rotatePointX += d - old;
		CubeHandler.cubes[CubeHandler.selectedCube].posX = d;
		GameObject.FindGameObjectWithTag("xPos").GetComponent<InputField>().text = d + "";
		CubeHandler.updateCube(CubeHandler.selectedCube);
	}
	
	public void onPosXDown()
	{
		float d;
		float.TryParse(GameObject.FindGameObjectWithTag("xPos").GetComponent<InputField>().text, out d);
		float old = d;
		if (d % 1f == 0) d--;
		else d -= 0.1f;
		CubeHandler.cubes[CubeHandler.selectedCube].rotatePointX += d - old;
		CubeHandler.cubes[CubeHandler.selectedCube].posX = d;
		GameObject.FindGameObjectWithTag("xPos").GetComponent<InputField>().text = d + "";
		CubeHandler.updateCube(CubeHandler.selectedCube);
	}
	
	public void onPosYChange(string pos)
	{
		if (notSelecting)
		{
			float old = CubeHandler.cubes[CubeHandler.selectedCube].posY;
			float.TryParse(pos, out CubeHandler.cubes[CubeHandler.selectedCube].posY);
			CubeHandler.cubes[CubeHandler.selectedCube].rotatePointY += CubeHandler.cubes[CubeHandler.selectedCube].posY - old;
			CubeHandler.updateCube(CubeHandler.selectedCube);
		}
	}
	
	public void onPosYUp()
	{
		float d;
		float.TryParse(GameObject.FindGameObjectWithTag("yPos").GetComponent<InputField>().text, out d);
		float old = d;
		if (d % 1f == 0) d++;
		else d += 0.1f;
		CubeHandler.cubes[CubeHandler.selectedCube].rotatePointY += d - old;
		GameObject.FindGameObjectWithTag("yPos").GetComponent<InputField>().text = d + "";
		CubeHandler.updateCube(CubeHandler.selectedCube);
	}
	
	public void onPosYDown()
	{
		float d;
		float.TryParse(GameObject.FindGameObjectWithTag("yPos").GetComponent<InputField>().text, out d);
		float old = d;
		if (d % 1f == 0) d--;
		else d -= 0.1f;
		CubeHandler.cubes[CubeHandler.selectedCube].rotatePointY += d - old;
		CubeHandler.cubes[CubeHandler.selectedCube].posY = d;
		GameObject.FindGameObjectWithTag("yPos").GetComponent<InputField>().text = d + "";
		CubeHandler.updateCube(CubeHandler.selectedCube);
	}
	
	public void onPosZChange(string pos)
	{
		if (notSelecting)
		{
			float old = CubeHandler.cubes[CubeHandler.selectedCube].posZ;
			float.TryParse(pos, out CubeHandler.cubes[CubeHandler.selectedCube].posZ);
			CubeHandler.cubes[CubeHandler.selectedCube].rotatePointZ += CubeHandler.cubes[CubeHandler.selectedCube].posZ - old;
			CubeHandler.updateCube(CubeHandler.selectedCube);
		}
	}
	
	public void onPosZUp()
	{
		float d;
		float.TryParse(GameObject.FindGameObjectWithTag("zPos").GetComponent<InputField>().text, out d);
		float old = d;
		if (d % 1f == 0) d++;
		else d += 0.1f;
		CubeHandler.cubes[CubeHandler.selectedCube].rotatePointZ += d - old;
		CubeHandler.cubes[CubeHandler.selectedCube].posZ = d;
		GameObject.FindGameObjectWithTag("zPos").GetComponent<InputField>().text = d + "";
		CubeHandler.updateCube(CubeHandler.selectedCube);
	}
	
	public void onPosZDown()
	{
		float d;
		float.TryParse(GameObject.FindGameObjectWithTag("zPos").GetComponent<InputField>().text, out d);
		float old = d;
		if (d % 1f == 0) d--;
		else d -= 0.1f;
		CubeHandler.cubes[CubeHandler.selectedCube].rotatePointZ += d - old;
		CubeHandler.cubes[CubeHandler.selectedCube].posZ = d;
		GameObject.FindGameObjectWithTag("zPos").GetComponent<InputField>().text = d + "";
		CubeHandler.updateCube(CubeHandler.selectedCube);
	}
	
	public void onDimensionXChange(string dimension)
	{
		if (notSelecting)
		{
			bool change = CubeHandler.cubes[CubeHandler.selectedCube].dimensionX / 2 ==
			              CubeHandler.cubes[CubeHandler.selectedCube].rotatePointX - CubeHandler.cubes[CubeHandler.selectedCube].posX;
			float.TryParse(dimension, out CubeHandler.cubes[CubeHandler.selectedCube].dimensionX);
			if (change)
			{
				CubeHandler.cubes[CubeHandler.selectedCube].rotatePointX =
					CubeHandler.cubes[CubeHandler.selectedCube].dimensionX / 2;
				GameObject.FindGameObjectWithTag("xRotationPoint").GetComponent<InputField>().text =
					CubeHandler.cubes[CubeHandler.selectedCube].rotatePointX + "";
			}
			CubeHandler.updateCube(CubeHandler.selectedCube);
		}
	}
	
	public void onDimensionXUp()
	{
		float d;
		bool change = CubeHandler.cubes[CubeHandler.selectedCube].dimensionX / 2 ==
		    CubeHandler.cubes[CubeHandler.selectedCube].rotatePointX  - CubeHandler.cubes[CubeHandler.selectedCube].posX;
		float.TryParse(GameObject.FindGameObjectWithTag("xDimension").GetComponent<InputField>().text, out d);
		if (d % 1f == 0) d++;
		else d += 0.1f;
		if (change)
		{
			CubeHandler.cubes[CubeHandler.selectedCube].rotatePointX =
				d / 2;
			GameObject.FindGameObjectWithTag("xRotationPoint").GetComponent<InputField>().text = d / 2 + "";
		}
		CubeHandler.cubes[CubeHandler.selectedCube].dimensionX = d;
		GameObject.FindGameObjectWithTag("xDimension").GetComponent<InputField>().text = d + "";
		CubeHandler.updateCube(CubeHandler.selectedCube);
	}
	
	public void onDimensionXDown()
	{
		float d;
		bool change = CubeHandler.cubes[CubeHandler.selectedCube].dimensionX / 2 ==
		              CubeHandler.cubes[CubeHandler.selectedCube].rotatePointX - CubeHandler.cubes[CubeHandler.selectedCube].posX;
		float.TryParse(GameObject.FindGameObjectWithTag("xDimension").GetComponent<InputField>().text, out d);
		if (d % 1f == 0) d--;
		else d -= 0.1f;
		if (change)
		{
			CubeHandler.cubes[CubeHandler.selectedCube].rotatePointX =
				d / 2;
			GameObject.FindGameObjectWithTag("xRotationPoint").GetComponent<InputField>().text = d / 2 + "";
		}
		CubeHandler.cubes[CubeHandler.selectedCube].dimensionX = d;
		GameObject.FindGameObjectWithTag("xDimension").GetComponent<InputField>().text = d + "";
		CubeHandler.updateCube(CubeHandler.selectedCube);
	}
	
	public void onDimensionYChange(string dimension)
	{
		if (notSelecting)
		{
			bool change = CubeHandler.cubes[CubeHandler.selectedCube].dimensionY / 2 ==
			              CubeHandler.cubes[CubeHandler.selectedCube].rotatePointY - CubeHandler.cubes[CubeHandler.selectedCube].posY;
			float.TryParse(dimension, out CubeHandler.cubes[CubeHandler.selectedCube].dimensionY);
			if (change)
			{
				CubeHandler.cubes[CubeHandler.selectedCube].rotatePointY =
					CubeHandler.cubes[CubeHandler.selectedCube].dimensionY / 2;
				GameObject.FindGameObjectWithTag("yRotationPoint").GetComponent<InputField>().text =
					CubeHandler.cubes[CubeHandler.selectedCube].rotatePointY + "";
			}
			CubeHandler.updateCube(CubeHandler.selectedCube);
		}
	}
	
	public void onDimensionYUp()
	{
		float d;
		bool change = CubeHandler.cubes[CubeHandler.selectedCube].dimensionY / 2 ==
		              CubeHandler.cubes[CubeHandler.selectedCube].rotatePointY - CubeHandler.cubes[CubeHandler.selectedCube].posY;
		float.TryParse(GameObject.FindGameObjectWithTag("yDimension").GetComponent<InputField>().text, out d);
		if (d % 1f == 0) d++;
		else d += 0.1f;
		if (change)
		{
			CubeHandler.cubes[CubeHandler.selectedCube].rotatePointY =
				d / 2;
			GameObject.FindGameObjectWithTag("yRotationPoint").GetComponent<InputField>().text = d / 2 + "";
		}
		CubeHandler.cubes[CubeHandler.selectedCube].dimensionY = d;
		GameObject.FindGameObjectWithTag("yDimension").GetComponent<InputField>().text = d + "";
		CubeHandler.updateCube(CubeHandler.selectedCube);
	}
	
	public void onDimensionYDown()
	{
		float d;
		bool change = CubeHandler.cubes[CubeHandler.selectedCube].dimensionY / 2 ==
		              CubeHandler.cubes[CubeHandler.selectedCube].rotatePointY - CubeHandler.cubes[CubeHandler.selectedCube].posY;
		float.TryParse(GameObject.FindGameObjectWithTag("yDimension").GetComponent<InputField>().text, out d);
		if (d % 1f == 0) d--;
		else d -= 0.1f;
		if (change)
		{
			CubeHandler.cubes[CubeHandler.selectedCube].rotatePointY =
				d / 2;
			GameObject.FindGameObjectWithTag("yRotationPoint").GetComponent<InputField>().text = d / 2 + "";
		}
		CubeHandler.cubes[CubeHandler.selectedCube].dimensionY = d;
		GameObject.FindGameObjectWithTag("yDimension").GetComponent<InputField>().text = d + "";
		CubeHandler.updateCube(CubeHandler.selectedCube);
	}
	
	public void onDimensionZChange(string dimension)
	{
		if (notSelecting)
		{
			bool change = CubeHandler.cubes[CubeHandler.selectedCube].dimensionZ / 2 ==
			              CubeHandler.cubes[CubeHandler.selectedCube].rotatePointZ - CubeHandler.cubes[CubeHandler.selectedCube].posZ;
			float.TryParse(dimension, out CubeHandler.cubes[CubeHandler.selectedCube].dimensionZ);
			if (change)
			{
				CubeHandler.cubes[CubeHandler.selectedCube].rotatePointZ =
					CubeHandler.cubes[CubeHandler.selectedCube].dimensionZ / 2;
				GameObject.FindGameObjectWithTag("zRotationPoint").GetComponent<InputField>().text =
					CubeHandler.cubes[CubeHandler.selectedCube].rotatePointZ + "";
			}
			CubeHandler.updateCube(CubeHandler.selectedCube);
		}
	}
	
	public void onDimensionZUp()
	{
		float d;
		bool change = CubeHandler.cubes[CubeHandler.selectedCube].dimensionZ / 2 ==
		              CubeHandler.cubes[CubeHandler.selectedCube].rotatePointZ - CubeHandler.cubes[CubeHandler.selectedCube].posZ;
		float.TryParse(GameObject.FindGameObjectWithTag("zDimension").GetComponent<InputField>().text, out d);
		if (d % 1f == 0) d++;
		else d += 0.1f;
		if (change)
		{
			CubeHandler.cubes[CubeHandler.selectedCube].rotatePointZ =
				d / 2;
			GameObject.FindGameObjectWithTag("zRotationPoint").GetComponent<InputField>().text = d / 2 + "";
		}
		CubeHandler.cubes[CubeHandler.selectedCube].dimensionZ = d;
		GameObject.FindGameObjectWithTag("zDimension").GetComponent<InputField>().text = d + "";
		CubeHandler.updateCube(CubeHandler.selectedCube);
	}
	
	public void onDimensionZDown()
	{
		float d;
		bool change = CubeHandler.cubes[CubeHandler.selectedCube].dimensionZ / 2 ==
		              CubeHandler.cubes[CubeHandler.selectedCube].rotatePointZ - CubeHandler.cubes[CubeHandler.selectedCube].posZ;
		float.TryParse(GameObject.FindGameObjectWithTag("zDimension").GetComponent<InputField>().text, out d);
		if (d % 1f == 0) d--;
		else d -= 0.1f;
		if (change)
		{
			CubeHandler.cubes[CubeHandler.selectedCube].rotatePointZ =
				d / 2;
			GameObject.FindGameObjectWithTag("zRotationPoint").GetComponent<InputField>().text = d / 2 + "";
		}
		CubeHandler.cubes[CubeHandler.selectedCube].dimensionZ = d;
		GameObject.FindGameObjectWithTag("zDimension").GetComponent<InputField>().text = d + "";
		CubeHandler.updateCube(CubeHandler.selectedCube);
	}
	
	public void onRotationXChange(string rotation)
	{
		if (notSelecting)
		{
			float.TryParse(rotation, out CubeHandler.cubes[CubeHandler.selectedCube].rotationX);
			GameObject.FindGameObjectWithTag("xRotationSlider").GetComponent<Slider>().value =
				(CubeHandler.cubes[CubeHandler.selectedCube].rotationX + 180) / 360;
			CubeHandler.updateCube(CubeHandler.selectedCube);
		}
	}
	
	public void onRotationXUp()
	{
		float d;
		float.TryParse(GameObject.FindGameObjectWithTag("xRotation").GetComponent<InputField>().text, out d);
		if (d % 1f == 0) d++;
		else d += 0.1f;
		CubeHandler.cubes[CubeHandler.selectedCube].rotationX = d;
		GameObject.FindGameObjectWithTag("xRotation").GetComponent<InputField>().text = d + "";
		GameObject.FindGameObjectWithTag("xRotationSlider").GetComponent<Slider>().value = (d + 180) / 360;
		CubeHandler.updateCube(CubeHandler.selectedCube);
	}
	
	public void onRotationXDown()
	{
		float d;
		float.TryParse(GameObject.FindGameObjectWithTag("xRotation").GetComponent<InputField>().text, out d);
		if (d % 1f == 0) d--;
		else d -= 0.1f;
		CubeHandler.cubes[CubeHandler.selectedCube].rotationX = d;
		GameObject.FindGameObjectWithTag("xRotation").GetComponent<InputField>().text = d + "";
		GameObject.FindGameObjectWithTag("xRotationSlider").GetComponent<Slider>().value = (d + 180) / 360;
		CubeHandler.updateCube(CubeHandler.selectedCube);
	}
	
	public void onRotationYChange(string rotation)
	{
		if (notSelecting)
		{
			float.TryParse(rotation, out CubeHandler.cubes[CubeHandler.selectedCube].rotationY);
			GameObject.FindGameObjectWithTag("yRotationSlider").GetComponent<Slider>().value =
				(CubeHandler.cubes[CubeHandler.selectedCube].rotationY + 180) / 360;
			CubeHandler.updateCube(CubeHandler.selectedCube);
		}
	}
	
	public void onRotationYUp()
	{
		float d;
		float.TryParse(GameObject.FindGameObjectWithTag("yRotation").GetComponent<InputField>().text, out d);
		if (d % 1f == 0) d++;
		else d += 0.1f;
		CubeHandler.cubes[CubeHandler.selectedCube].rotationY = d;
		GameObject.FindGameObjectWithTag("yRotation").GetComponent<InputField>().text = d + "";
		GameObject.FindGameObjectWithTag("yRotationSlider").GetComponent<Slider>().value = (d + 180) / 360;
		CubeHandler.updateCube(CubeHandler.selectedCube);
	}
	
	public void onRotationYDown()
	{
		float d;
		float.TryParse(GameObject.FindGameObjectWithTag("yRotation").GetComponent<InputField>().text, out d);
		if (d % 1f == 0) d--;
		else d -= 0.1f;
		CubeHandler.cubes[CubeHandler.selectedCube].rotationY = d;
		GameObject.FindGameObjectWithTag("yRotation").GetComponent<InputField>().text = d + "";
		GameObject.FindGameObjectWithTag("yRotationSlider").GetComponent<Slider>().value = (d + 180) / 360;
		CubeHandler.updateCube(CubeHandler.selectedCube);
	}
	
	public void onRotationZChange(string rotation)
	{
		if (notSelecting)
		{
			float.TryParse(rotation, out CubeHandler.cubes[CubeHandler.selectedCube].rotationZ);
			GameObject.FindGameObjectWithTag("zRotationSlider").GetComponent<Slider>().value =
				(CubeHandler.cubes[CubeHandler.selectedCube].rotationZ + 180) / 360;
			CubeHandler.updateCube(CubeHandler.selectedCube);
		}
	}
	
	public void onRotationZUp()
	{
		float d;
		float.TryParse(GameObject.FindGameObjectWithTag("zRotation").GetComponent<InputField>().text, out d);
		if (d % 1f == 0) d++;
		else d += 0.1f;
		CubeHandler.cubes[CubeHandler.selectedCube].rotationZ = d;
		GameObject.FindGameObjectWithTag("zRotation").GetComponent<InputField>().text = d + "";
		GameObject.FindGameObjectWithTag("zRotationSlider").GetComponent<Slider>().value = (d + 180) / 360;
		CubeHandler.updateCube(CubeHandler.selectedCube);
	}
	
	public void onRotationZDown()
	{
		float d;
		float.TryParse(GameObject.FindGameObjectWithTag("zRotation").GetComponent<InputField>().text, out d);
		if (d % 1f == 0) d--;
		else d -= 0.1f;
		CubeHandler.cubes[CubeHandler.selectedCube].rotationZ = d;
		GameObject.FindGameObjectWithTag("zRotation").GetComponent<InputField>().text = d + "";
		GameObject.FindGameObjectWithTag("zRotationSlider").GetComponent<Slider>().value = (d + 180) / 360;
		CubeHandler.updateCube(CubeHandler.selectedCube);
	}
	
	public void onRotationSliderXChange(float rotation)
	{
		if (notSelecting)
		{
			CubeHandler.cubes[CubeHandler.selectedCube].rotationX = rotation * 360 - 180;
			CubeHandler.updateCube(CubeHandler.selectedCube);
		}
	}
	
	public void onRotationSliderYChange(float rotation)
	{
		if (notSelecting)
		{
			CubeHandler.cubes[CubeHandler.selectedCube].rotationY = rotation * 360 - 180;
			CubeHandler.updateCube(CubeHandler.selectedCube);
		}
	}
	
	public void onRotationSliderZChange(float rotation)
	{
		if (notSelecting)
		{
			CubeHandler.cubes[CubeHandler.selectedCube].rotationZ = rotation * 360 - 180;
			CubeHandler.updateCube(CubeHandler.selectedCube);
		}
	}
	
	public void onRotationPointXChange(string rotation)
	{
		if (notSelecting)
		{
			float.TryParse(rotation, out CubeHandler.cubes[CubeHandler.selectedCube].rotatePointX);
			CubeHandler.cubes[CubeHandler.selectedCube].rotatePointX += CubeHandler.cubes[CubeHandler.selectedCube].posX;
			CubeHandler.updateCube(CubeHandler.selectedCube);
		}
	}
	
	public void onRotationPointXUp()
	{
		float d;
		d = CubeHandler.cubes[CubeHandler.selectedCube].rotatePointX;
		if (d % 1f == 0) d++;
		else d += 0.1f;
		CubeHandler.cubes[CubeHandler.selectedCube].rotatePointX = d;
		GameObject.FindGameObjectWithTag("xRotationPoint").GetComponent<InputField>().text = d - CubeHandler.cubes[CubeHandler.selectedCube].posX + "";
		CubeHandler.updateCube(CubeHandler.selectedCube);
	}
	
	public void onRotationPointXDown()
	{
		float d;
		d = CubeHandler.cubes[CubeHandler.selectedCube].rotatePointX;
		if (d % 1f == 0) d--;
		else d -= 0.1f;
		CubeHandler.cubes[CubeHandler.selectedCube].rotatePointX = d;
		GameObject.FindGameObjectWithTag("xRotationPoint").GetComponent<InputField>().text = d - CubeHandler.cubes[CubeHandler.selectedCube].posX + "";
		CubeHandler.updateCube(CubeHandler.selectedCube);
	}
	
	public void onRotationPointYChange(string rotation)
	{
		if (notSelecting)
		{
			float.TryParse(rotation, out CubeHandler.cubes[CubeHandler.selectedCube].rotatePointY);
			CubeHandler.cubes[CubeHandler.selectedCube].rotatePointY += CubeHandler.cubes[CubeHandler.selectedCube].posY;
			CubeHandler.updateCube(CubeHandler.selectedCube);
		}
	}
	
	public void onRotationPointYUp()
	{
		float d;
		d = CubeHandler.cubes[CubeHandler.selectedCube].rotatePointY;
		if (d % 1f == 0) d++;
		else d += 0.1f;
		CubeHandler.cubes[CubeHandler.selectedCube].rotatePointY = d;
		GameObject.FindGameObjectWithTag("yRotationPoint").GetComponent<InputField>().text = d - CubeHandler.cubes[CubeHandler.selectedCube].posY + "";
		CubeHandler.updateCube(CubeHandler.selectedCube);
	}
	
	public void onRotationPointYDown()
	{
		float d;
		d = CubeHandler.cubes[CubeHandler.selectedCube].rotatePointY;
		if (d % 1f == 0) d--;
		else d -= 0.1f;
		CubeHandler.cubes[CubeHandler.selectedCube].rotatePointY = d;
		GameObject.FindGameObjectWithTag("yRotationPoint").GetComponent<InputField>().text = d - CubeHandler.cubes[CubeHandler.selectedCube].posY + "";
		CubeHandler.updateCube(CubeHandler.selectedCube);
	}
	
	public void onRotationPointZChange(string rotation)
	{
		if (notSelecting)
		{
			float.TryParse(rotation, out CubeHandler.cubes[CubeHandler.selectedCube].rotatePointZ);
			CubeHandler.cubes[CubeHandler.selectedCube].rotatePointZ += CubeHandler.cubes[CubeHandler.selectedCube].posZ;
			CubeHandler.updateCube(CubeHandler.selectedCube);
		}
	}
	
	public void onRotationPointZUp()
	{
		float d;
		d = CubeHandler.cubes[CubeHandler.selectedCube].rotatePointZ;
		if (d % 1f == 0) d++;
		else d += 0.1f;
		CubeHandler.cubes[CubeHandler.selectedCube].rotatePointZ = d;
		GameObject.FindGameObjectWithTag("zRotationPoint").GetComponent<InputField>().text = d - CubeHandler.cubes[CubeHandler.selectedCube].posZ + "";
		CubeHandler.updateCube(CubeHandler.selectedCube);
	}
	
	public void onRotationPointZDown()
	{
		float d;
		d = CubeHandler.cubes[CubeHandler.selectedCube].rotatePointZ;
		if (d % 1f == 0) d--;
		else d -= 0.1f;
		CubeHandler.cubes[CubeHandler.selectedCube].rotatePointZ = d;
		GameObject.FindGameObjectWithTag("zRotationPoint").GetComponent<InputField>().text = d - CubeHandler.cubes[CubeHandler.selectedCube].posZ + "";
		CubeHandler.updateCube(CubeHandler.selectedCube);
	}
	
	public void onCreateCube()
	{
		cubie = CubeHandler.CreateACube();
	}
}
