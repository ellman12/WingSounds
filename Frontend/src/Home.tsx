import SoundButton from "./components/SoundButton.tsx";

export default function Home() {
    return (
        <div className="bg-[#111214] w-full h-full">
            <SoundButton sound={{name: "Bombs", sound_id: "1349243344420606034", guild_id: "1349171772695773305"}}/>
        </div>
    );
}