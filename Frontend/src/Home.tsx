import SoundButtons from "./components/SoundButtons.tsx";

export default function Home() {
    return (
        <div className="flex flex-col gap-4 w-full h-full p-8">
            <h1 className="text-2xl text-white">WingTech Bot Mk 2 Soundboard</h1>

            <SoundButtons />
        </div>
    );
}