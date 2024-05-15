"use client";

import { useState } from "react";

export default function Therapist() {
  const [text, setText] = useState("");
  const [audioUrl, setAudioUrl] = useState<string | null>(null);

  const handleSubmit = async () => {
    const res = await fetch("/api/ai-therapist/speak", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ text })
    });

    if (res.ok) {
      const blob = await res.blob();
      const url = URL.createObjectURL(blob);
      setAudioUrl(url);
    }
  };

  return (
    <div className="flex flex-col items-center p-8">
      <textarea
        placeholder="Type your feelings here..."
        value={text}
        onChange={(e) => setText(e.target.value)}
        className="w-full p-4 mb-4 border rounded-md"
      />

      <button
        onClick={handleSubmit}
        className="bg-blue-500 text-white py-2 px-6 rounded-md"
      >
        Speak to me i am always here 
      </button>

      {audioUrl && (
        <audio controls className="mt-4">
          <source src={audioUrl} type="audio/mpeg" />
        </audio>
      )}
    </div>
  );
}
