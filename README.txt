This application is windows only.



1. Sign up for Gemini API and ElevenLabs.
2. Generate keys for both.
3. Set the environment variable before running the app:

	**Windows (PowerShell):**
	setx GEMINI_API_KEY "your_api_key_here"
	ELEVENLABS_API_KEY "your_api_key_here"

4. Make sure python and pip is installed. Run the following command.

	pip install python-dotenv requests elevenlabs

5. Run the app. The API keys will be read automatically.