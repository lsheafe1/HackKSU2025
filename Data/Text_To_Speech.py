# example.py
import os
from io import BytesIO
from dotenv import load_dotenv
import requests
from elevenlabs.client import ElevenLabs
import tempfile


load_dotenv()
elevenlabs = ElevenLabs(
  api_key=os.environ.get("ELEVENLABS_API_KEY"),
)
'''
audio_url = (
    "https://storage.googleapis.com/eleven-public-cdn/audio/marketing/nicole.mp3"
)
response = requests.get(audio_url)
audio_data = BytesIO(response.content)
'''
file_path = os.path.join(tempfile.gettempdir(), "audio.wav")
with open(file_path, "rb") as f:
    transcription = elevenlabs.speech_to_text.convert(
        file=f,
        model_id="scribe_v1", # Model to use, for now only "scribe_v1" is supported
        tag_audio_events=True, # Tag audio events like laughter, applause, etc.
        language_code="eng", # Language of the audio file. If set to None, the model will detect the language automatically.
        diarize=True, # Whether to annotate who is speaking
    )

print(transcription.text)




