﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CubesList : MonoBehaviour
{
	public Font font;
	
	public static List<GameObject> texts = new List<GameObject>();


	public void onClone()
	{
		CubeHandler.CloneACube(CubeHandler.selectedCube);
	}
	
	public void onDelete()
	{
		CubeHandler.DeleteACube(CubeHandler.selectedCube);
	}
	
	public void onNew()
	{
		CubeHandler.CreateACube();
	}
	// Update is called once per frame
	void Update ()
	{
		List<Cube> list = getAllCubes(CubeHandler.cubes);
		if (texts.Count == list.Count)
		{
			for (int i = 0; i < list.Count; i++)
			{
				texts[i].GetComponentInChildren<Text>().text = list[i].name;
			}
		}
		else
		{
			if (texts.Count > list.Count)
			{
				for (int i = list.Count; i < texts.Count; i++)
				{
					Destroy(texts[i]);
					texts.RemoveAt(i);
				}
			}
			else
			{
				texts.Add(CreateText(5, -25 + texts.Count * -20, list[texts.Count].name, 15, Color.white, texts.Count));
			}
		}
	}

	List<Cube> getAllCubes(List<Cube> cubes)
	{
		return cubes;
	}
	
	GameObject CreateText(float x, float y, string text_to_print, int font_size, Color text_color, int id)
	{
		GameObject UIbuttonGO = new GameObject("Button");
		GameObject UItextGO = new GameObject("Text");
		UIbuttonGO.transform.SetParent(this.transform);
		UItextGO.transform.SetParent(UIbuttonGO.transform);

		RectTransform trans = UIbuttonGO.AddComponent<RectTransform>();
		trans.anchorMin = new Vector2(0, 1);
		trans.anchorMax = new Vector2(0, 1);
		trans.offsetMin = new Vector2(x, y);
		trans.offsetMax = new Vector2(x + 100, y - 20);

		Button button = UIbuttonGO.AddComponent<Button>();
		button.onClick.AddListener(() =>
		{
			CubeHandler.SelectCube(id);
		});
		
		Text text = UItextGO.AddComponent<Text>();
		RectTransform trans2 = UItextGO.GetComponent<RectTransform>();
		trans2.sizeDelta = new Vector2(100, 20);
		text.text = text_to_print;
		text.fontSize = font_size;
		text.font = font;
		text.color = text_color;
		return UIbuttonGO;
	}
}
