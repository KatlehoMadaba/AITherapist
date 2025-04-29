// components/AiTherapistChat.tsx
"use client";

import { useState } from 'react';
import axios from 'axios';

export default function AiTherapistChat() {
  const [messages, setMessages] = useState<{ sender: string; text: string }[]>([]);
  const [input, setInput] = useState('');
  const [loading, setLoading] = useState(false);

  const sendMessage = async () => {
    if (!input.trim()) return;
    setMessages([...messages, { sender: 'user', text: input }]);
    setLoading(true);

    try {
      const response = await axios.post('https://localhost:44311/message', { message: input });
      const aiReply = response.data.reply;
      setMessages(prev => [...prev, { sender: 'ai', text: aiReply }]);
      setInput('');
    } catch (error) {
      console.error(error);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="p-4">
      <div className="h-[400px] overflow-y-auto border p-2 rounded">
        {messages.map((msg, idx) => (
          <div key={idx} className={`my-2 ${msg.sender === 'user' ? 'text-right' : 'text-left'}`}>
            <p className="inline-block p-2 rounded bg-gray-200">{msg.text}</p>
          </div>
        ))}
      </div>

      <div className="flex mt-4">
        <input
          className="border p-2 flex-1 rounded"
          value={input}
          onChange={(e) => setInput(e.target.value)}
          placeholder="Type your feelings here..."
        />
        <button onClick={sendMessage} disabled={loading} className="ml-2 bg-blue-500 text-white p-2 rounded">
          {loading ? 'Sending...' : 'Send'}
        </button>
      </div>
    </div>
  );
}
