import SoundButtons from "./components/SoundButtons.tsx";

export default function Home() {
    return (
        <div className="bg-[#111214] flex flex-col gap-4 w-full h-full p-16">
            <h1 className="text-2xl text-white">WingTech Bot Mk 2 Soundboard</h1>

            <SoundButtons />
        </div>
    );
}