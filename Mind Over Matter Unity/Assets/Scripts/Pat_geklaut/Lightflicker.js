 @script RequireComponent(Light)
 
 var minIntensity = 0.25f;
 var maxIntensity = 0.5f;
 
 private var random : float;  
 
 random = Random.Range(0.0f, 65535.0f);
 
 function Update()
 {
     var noise = Mathf.PerlinNoise(random, Time.time);
     GetComponent.<Light>().intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);
 }
