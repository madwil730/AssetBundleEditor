using Firebase.Storage;
using Newtonsoft.Json.Bson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FireBaseUpload : MonoBehaviour
{


	public void AssetUpload()
	{
		StartCoroutine(upload());
	}

	private IEnumerator upload()
	{
		string modelPath = Path.Combine(Application.dataPath, "Manifast/model");
		string materialPath = Path.Combine(Application.dataPath, "Manifast/material");
		string texturePath = Path.Combine(Application.dataPath, "Manifast/png");
		string manifastPath = Path.Combine(Application.dataPath, "Manifast/Manifast");

		//model
		FirebaseStorage storage = FirebaseStorage.DefaultInstance;
		var storageReference = storage.GetReference("model");
		var uploadTask = storageReference.PutFileAsync(modelPath, null,
		new StorageProgress<UploadState>(state =>
		{
			Debug.Log(String.Format("Progress: {0} of {1} bytes transferred.", state.BytesTransferred, state.TotalByteCount));
		}), CancellationToken.None, null);

		yield return new WaitUntil(() => uploadTask.IsCompleted);

		if (uploadTask.Exception != null)
		{
			Debug.LogError($"Failed upload : {uploadTask.Exception}");
			yield break;
		}
		Debug.Log("##############Upload model###############");

		//material
		storageReference = storage.GetReference("material");
		uploadTask = storageReference.PutFileAsync(materialPath, null,
		new StorageProgress<UploadState>(state =>
		{
			Debug.Log(String.Format("Progress: {0} of {1} bytes transferred.", state.BytesTransferred, state.TotalByteCount));
		}), CancellationToken.None, null);

		yield return new WaitUntil(() => uploadTask.IsCompleted);

		if (uploadTask.Exception != null)
		{
			Debug.LogError($"Failed upload : {uploadTask.Exception}");
			yield break;
		}
		Debug.Log("##############Upload material###############");

		//texture
		storageReference = storage.GetReference("png");
		uploadTask = storageReference.PutFileAsync(texturePath, null,
		new StorageProgress<UploadState>(state =>
		{
			Debug.Log(String.Format("Progress: {0} of {1} bytes transferred.", state.BytesTransferred, state.TotalByteCount));
		}), CancellationToken.None, null);

		yield return new WaitUntil(() => uploadTask.IsCompleted);

		if (uploadTask.Exception != null)
		{
			Debug.LogError($"Failed upload : {uploadTask.Exception}");
			yield break;
		}
		Debug.Log("##############Upload texture###############");

		//manifast
		storageReference = storage.GetReference("manifast");
		uploadTask = storageReference.PutFileAsync(manifastPath, null,
		new StorageProgress<UploadState>(state =>
		{
			Debug.Log(String.Format("Progress: {0} of {1} bytes transferred.", state.BytesTransferred, state.TotalByteCount));
		}), CancellationToken.None, null);

		yield return new WaitUntil(() => uploadTask.IsCompleted);

		if (uploadTask.Exception != null)
		{
			Debug.LogError($"Failed upload : {uploadTask.Exception}");
			yield break;
		}
		Debug.Log("##############Upload manifast###############");
	}
}
