export async function getTherapistVoice(text: string): Promise<Blob> {
    const response = await fetch("/api/ai-therapist", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ text })
    });
  
    if (!response.ok) throw new Error("Failed to get audio");
  
    const blob = await response.blob();
    return blob;
  }
  