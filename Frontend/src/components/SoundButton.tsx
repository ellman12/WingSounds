import {FC} from "react";
import SoundboardSound from "../api/SoundboardSound.ts";
import http from "../api/http.ts";

interface Props {
    sound: SoundboardSound;
}

const SoundButton: FC<Props> = ({sound}) => {
    async function onClick() {
        await sendSound();
    }

    async function sendSound() {
        await http.post("soundboard/send-soundboard-sound", {guild_id: sound.guild_id, sound_id: sound.sound_id});
    }

    return (
        <button className="mx-64" onClick={onClick}>
            {sound.name}
        </button>
    );
};

export default SoundButton;
